using EPiServer.ContentGraph.Api.Querying;
using EPiServer.ContentGraph.Api.Result;
using EPiServer.ContentGraph.Extensions;
using MediatR;
using GraphModels = Cms.Features.Graph;

namespace Cms.Features.Pages.Search;

public sealed class SearchListingQueryHandler : IRequestHandler<SearchListingQuery, SearchListingResults>
{
    private readonly GraphQueryBuilder _queryBuilder;

    public SearchListingQueryHandler(GraphQueryBuilder queryBuilder)
    {
        _queryBuilder = queryBuilder;
    }

    public async Task<SearchListingResults> Handle(SearchListingQuery request, CancellationToken cancellationToken)
    {
        var query = _queryBuilder.OperationName("Standard_Search")
                                 .ForType<GraphModels.Content>()
                                 .Skip(0)
                                 .Limit(10)
                                 .Fields(a => a.Name,
                                         b => b.StartPublish,
                                         c => c.ContentLink!.Id)
                                 .AddCommonPropertiesForAllPages()
                                 .Total()
                                 .Search(request.SearchText)
                                 .FilterForVisitor()
                                 .UsingSynonyms()
                                 .ToQuery()
                                 .BuildQueries();

        var content = await query.GetResultAsync();
        var sitePageDatas = content.GetContent<GraphModels.Content, GraphModels.SitePageData>();

        return new SearchListingResults
        {
            Results = GetResultModels(content.GetContent<GraphModels.Content, GraphModels.SitePageData>()).ToList()
        };
    }

    private static IEnumerable<SearchListingResult> GetResultModels(ContentGraphHits<GraphModels.SitePageData>? hits)
    {
        if (hits?.Hits is null)
        {
            yield break;
        }

        foreach(var hit in hits.Hits)
        {
            yield return new SearchListingResult { Id = hit.ContentLink?.Id ?? 0, Title = hit.TeaserTitle ?? hit.Name };
        }
    }
}

public static class CustomGraphExtensions
{
    public static TypeQueryBuilder<GraphModels.Content> AddCommonPropertiesForAllPages(this TypeQueryBuilder<GraphModels.Content> query)
    {
        return query.AddCommonProperties<GraphModels.HomePage>()
                    .AddCommonProperties<GraphModels.SearchPage>();
    }

    public static TypeQueryBuilder<GraphModels.Content> AddCommonProperties<TContent>(this TypeQueryBuilder<GraphModels.Content> query)
        where TContent : GraphModels.SitePageData
    {
        return query.AsType<TContent>(a => a.TeaserTitle, 
                                      b => b.TeaserText,
                                      c => c.TeaserImage!.Id,
                                      d => d.MetaTitle,
                                      e => e.MetaText,
                                      f => f.MetaImage!.Id);
    }
}
using MediatR;

namespace Cms.Features.Pages.Search;

public sealed class SearchListingQueryHandler : IRequestHandler<SearchListingQuery, SearchListingResults>
{
    public Task<SearchListingResults> Handle(SearchListingQuery request, CancellationToken cancellationToken)
    {
        var results = new List<SearchListingResult>
        {
            new() { Id = 1, Title = "Hello World" },
            new() { Id = 2, Title = "Hello Solar System" },
            new() { Id = 3, Title = "Hello Galaxy" },
            new() { Id = 4, Title = "Hello Universe" }
        };

        if (!string.IsNullOrWhiteSpace(request.SearchText))
        {
            var searchText = request.SearchText.Trim();

            results = results.Where(x => x.Title?.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
        }

        return Task.FromResult(new SearchListingResults
        {
            Results = results
        });
    }
}
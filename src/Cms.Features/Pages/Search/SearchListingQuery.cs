using MediatR;

namespace Cms.Features.Pages.Search;

public sealed class SearchListingQuery : IRequest<SearchListingResults>
{
    public string? SearchText { get; set; }
}
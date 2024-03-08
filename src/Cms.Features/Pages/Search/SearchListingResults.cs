namespace Cms.Features.Pages.Search;

public sealed class SearchListingResults
{
    public required IList<SearchListingResult> Results { get; set; } = [];
}
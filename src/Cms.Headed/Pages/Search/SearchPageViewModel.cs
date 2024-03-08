using Cms.Features.Pages.Search;

namespace Cms.Headed.Pages.Search
{
    public sealed class SearchPageViewModel : ISitePageViewModel<SearchPage>
    {
        public required SearchPage CurrentPage { get; set; }

        public required IList<SearchListingResult> SearchResults { get; set; }
    }
}

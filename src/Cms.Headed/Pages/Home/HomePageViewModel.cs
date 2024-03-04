using Cms.Features.Pages.Home;

namespace Cms.Headed.Pages.Home
{
    public class HomePageViewModel : ISitePageViewModel<HomePage>
    {
        public required HomePage CurrentPage { get; set; }
    }
}
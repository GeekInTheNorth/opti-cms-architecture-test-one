using Cms.Features.Pages.Home;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Headed.Pages.Home;

public sealed class HomePageController : PageController<HomePage>
{
    public IActionResult Index(HomePage currentPage)
    {
        var model = new HomePageViewModel { CurrentPage = currentPage };

        return View("HomePage.cshtml", model);
    }
}

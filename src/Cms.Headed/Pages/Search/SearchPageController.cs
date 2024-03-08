using Cms.Features.Pages.Search;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Headed.Pages.Search;

public sealed class SearchPageController : PageController<SearchPage>
{
    private readonly IMediator _mediator;

    public SearchPageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(SearchPage currentPage, string? searchText)
    {
        var results = await _mediator.Send(new SearchListingQuery { SearchText = searchText });

        var model = new SearchPageViewModel { CurrentPage = currentPage, SearchResults = results.Results };

        return View("~/Views/SearchPage/Index.cshtml", model);
    }
}

using Cms.Features.Pages.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Headless.Search;

public sealed class SearchApiController : Controller
{
    private readonly IMediator _mediator;

    public SearchApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("api/search")]
    public async Task<IActionResult> Search(string? searchText)
    {
        var result = await _mediator.Send(new SearchListingQuery { SearchText = searchText });

        return Ok(result);
    }
}
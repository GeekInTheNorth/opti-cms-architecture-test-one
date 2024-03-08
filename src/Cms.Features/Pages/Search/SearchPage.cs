using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Cms.Features.Pages.Search;

[ContentType(
    DisplayName = "Search",
    GUID = "fe351dca-304c-48a4-866b-ad7cd79bf60e")]
public class SearchPage : SitePageData
{
    [Display(
        Name = "Heading",
        Order = 10)]
    public virtual string? Heading { get; set; }
}
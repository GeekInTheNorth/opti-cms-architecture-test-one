using Cms.Features.Blocks;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Cms.Features.Pages.Home;

[ContentType(
    DisplayName = "Home",
    GUID = "2b18053e-cc86-4a66-abad-4616d81ddffa")]
public class HomePage : SitePageData
{
    [Display(
        Name = "Heading",
        Order = 10)]
    public virtual string? Heading { get; set; }

    [Display(
        Name = "Main Content",
        Order = 20)]
    [AllowedTypes(typeof(IContentBlock))]
    public virtual ContentArea? MainContent { get; set; }
}

using EPiServer.Core;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Cms.Features.Blocks.RichText;

[ContentType(
    DisplayName = "Rich Text",
    GUID = "9bfce21a-1a3b-4d5b-9c91-eed3c9f00866")]
public class RichTextBlock : BlockData
{
    [Display(
        Name = "Rich Text",
        Order = 10)]
    public virtual XhtmlString? Text { get; set; }
}

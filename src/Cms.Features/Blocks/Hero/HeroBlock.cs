using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Cms.Features.Blocks.Hero;

[ContentType(
    DisplayName = "Hero",
    GUID = "375bc31e-fc3b-4f5f-97bf-bc50358368d2")]
public class HeroBlock : BlockData
{
    public virtual string? Title { get; set; }
}

using Cms.Features.Blocks.RichText;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Headed.Blocks.RichText;

public class RichTextBlockViewComponent : BlockComponent<RichTextBlock>
{
    protected override IViewComponentResult InvokeComponent(RichTextBlock currentContent)
    {
        return View(currentContent);
    }
}
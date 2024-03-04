using EPiServer.Core;

namespace Cms.Features.Pages;

public interface ISitePageData
{
    string? TeaserTitle { get; }

    string? TeaserText { get; }

    ContentReference? TeaserImage { get; }

    string? MetaTitle { get; }

    string? MetaText { get; }

    ContentReference? MetaImage { get; }
}
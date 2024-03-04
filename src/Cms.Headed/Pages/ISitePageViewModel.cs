using Cms.Features.Pages;

namespace Cms.Headed.Pages;

public interface ISitePageViewModel<out T>
    where T : ISitePageData
{
    T CurrentPage { get; }
}
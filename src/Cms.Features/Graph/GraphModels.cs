using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Cms.Features.Graph
{
    public class SearchPage : SitePageData
    {
        public string? Heading { get; set; }
    }

    public class HomePage : SitePageData
    {
        public string? Heading { get; set; }

        public ContentArea? MainContent { get; set; }
    }

    public class SitePageData : Content
    {
        public string? TeaserTitle { get; set; }

        public string? TeaserText { get; set; }

        public ContentModelReference? TeaserImage { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaText { get; set; }

        public ContentModelReference? MetaImage { get; set; }
    }

    public class Content
    {
        public ContentModelReference? ContentLink { get; set; }
        
        [Searchable]
        public string? Name { get; set; }
        
        public ContentLanguageModel? Language { get; set; }
        
        public IEnumerable<ContentLanguageModel>? ExistingLanguages { get; set; }
        
        public ContentLanguageModel? MasterLanguage { get; set; }
        
        public IEnumerable<string>? ContentType { get; set; }
        
        public ContentModelReference? ParentLink { get; set; }
        
        public string? RouteSegment { get; set; }
        
        public string? Url { get; set; }
        
        public DateTime? Changed { get; set; }
        
        public DateTime? Created { get; set; }
        
        public DateTime? StartPublish { get; set; }
        
        public DateTime? StopPublish { get; set; }
        
        public DateTime? Saved { get; set; }
        
        public string? Status { get; set; }
        
        public IEnumerable<string>? Ancestors { get; set; }
        
        public bool IsCommonDraft { get; set; }
        
        public string? RelativePath { get; set; }
        
        public string? SiteId { get; set; }
    }
}

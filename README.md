# Architectural Proposal One

## Project Structure

The following project proposes a structuring of the solution projects as such:

![Project Structure](/Documents/ProposedArchitecture-Project%20Structure.jpg)

In this structure, the following responsibilities are placed against each project:

| Project | Responsibility | Required |
|-|-|-|
| Cms.Web | Core Website Functionality, limited to Startup, Program and service extensions | All |
| Cms.Headed | Presentation layer for a classic headed CMS. Contains Controllers, View Models and Razor files | Headed or Hybrid |
| Cms.Headless | API extensions for a headless CMS. | Hybrid or Headless |
| Cms.Features | Content Models and business logic inc. Scheduled Tasks, Search functionality etc. | All |

## Vertical Slice Architecture

In a Vertical Slice Architecture, the aim is to aim for high coupling / cohesion within a single feature and to decouple across features.  Increased maintainability comes from code being grouped within the same folder structure, developers do not have to navigate across several different projects and folder structures to find relevant code that they are editing.  The benefit of this approach is that a change to one feature affects just that feature and results in low risk and low retest requirements.  This does come at a cost that there will be some code repetition.  The challenge here is to correctly identify which elements of code should be common extension methods and which should or not be shared.

![Vertical / Feature Slices](/Documents/ProposedArchitecture-Feature%20Structure.jpg)

## Example Code Organisation

- **Cms.Web** (Web Project)
  - ServiceExtensions
    - CachedStaticFileServiceExtensions.cs
    - CookiePolicyServiceExtensions.cs
  - Program.cs
  - Startup.cs
- **Cms.Headed** (Razor Class Library)
  - Blocks
    - RichText
      - RichTextBlockViewComponent.cs
      - RichTextBlockViewModel.cs
      - RichTextBlockViewModelBuilder.cs
  - Pages
    - Home
      - HomePageController.cs
      - HomePageViewModel.cs
      - HomePageViewModelBuilder.cs
    - Search
      - SearchPageController.cs
      - SearchPageViewModel.cs
      - SearchPageViewModelBuilder.cs
    - ISitePageViewModel.cs
- **Cms.Headless** (Class Library)
  - Pages
    - Search
      - SearchApiController.cs
- **Cms.Features** (Class Library)
  - Blocks
    - RichText
      - RichTextBlock.cs
  - Pages
    - Home
      - HomePage.cs
      - HomePageValidator.cs
    - Search
      - SearchPage.cs
      - SearchPageValidator.cs
      - SearchPageQuery.cs
      - SearchPageQueryHandler.cs
    - SitePageData.cs
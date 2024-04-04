using Cms.Features.Pages.Home;
using Cms.Features.Pages.Search;
using Cms.Web.ServiceExtensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentGraph.Extensions;
using EPiServer.DependencyInjection;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Optimizely.ContentGraph.Cms.Configuration;

namespace Cms.Web;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services.AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddAdminUserRegistration(x => x.Behavior = RegisterAdminUserBehaviors.Enabled | RegisterAdminUserBehaviors.SingleUserOnly)
                .AddEmbeddedLocalization<Startup>();

        services.ConfigureContentApiOptions(o =>
        {
            o.IncludeInternalContentRoots = true;
            o.IncludeSiteHosts = true;
            //o.EnablePreviewFeatures = true;// optional
        });
        services.AddContentDeliveryApi();
        services.AddContentGraph(options =>
        {
            options.ContentVersionSyncMode = ContentVersionSyncMode.PublishedOnly;
            options.IncludeInheritanceInContentType = true;
            options.Include.ContentTypes = new[] { nameof(HomePage), nameof(SearchPage) };
        });
        services.AddContentGraphClient();

        services.Configure<EventIndexingOptions>(options =>
        {
            options.SyncContentTypesOnInit = true;
            options.Enable = true;
        });

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<SearchListingQuery>();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCachedStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSecureCookies();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
            endpoints.MapControllers();
        });
    }
}

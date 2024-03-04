using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Web.Routing;

namespace Cms.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        private readonly IConfiguration _configuration;

        public Startup(
            IWebHostEnvironment webHostingEnvironment,
            IConfiguration configuration)
        {
            _webHostingEnvironment = webHostingEnvironment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCmsAspNetIdentity<ApplicationUser>()
                    .AddCms()
                    .AddAdminUserRegistration(x => x.Behavior = RegisterAdminUserBehaviors.Enabled | RegisterAdminUserBehaviors.SingleUserOnly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/server-error");
            }

            app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
                endpoints.MapRazorPages();
            });
        }
    }
}

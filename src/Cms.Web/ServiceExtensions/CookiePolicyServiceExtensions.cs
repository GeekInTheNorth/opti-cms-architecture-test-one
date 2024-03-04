namespace Cms.Web.ServiceExtensions;

using Microsoft.AspNetCore.CookiePolicy;

public static class CookiePolicyServiceExtensions
{
    public static IApplicationBuilder UseSecureCookies(this IApplicationBuilder app)
    {
        app.UseCookiePolicy(new CookiePolicyOptions
        {
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always,
            MinimumSameSitePolicy = SameSiteMode.None,
            OnAppendCookie = context =>
            {
                if (!context.CookieName.StartsWith(".AspNetCore"))
                {
                    context.CookieOptions.SameSite = SameSiteMode.Strict;
                }
            }
        });

        return app;
    }
}
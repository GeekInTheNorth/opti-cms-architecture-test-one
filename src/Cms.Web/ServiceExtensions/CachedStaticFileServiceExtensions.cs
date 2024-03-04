namespace Cms.Web.ServiceExtensions;

using System.Net.Http.Headers;

public static class CachedStaticFileServiceExtensions
{
    public static IApplicationBuilder UseCachedStaticFiles(this IApplicationBuilder app)
    {
        var cacheHeaderValue = new CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromDays(365)
        }.ToString();

        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                ctx.Context.Response.Headers.CacheControl = cacheHeaderValue;
            }
        });

        return app;
    }
}
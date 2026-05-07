using Scalar.AspNetCore;

namespace rest_with_asp_net_10.Configuration
{
    public static class ScalarConfig
    {
        public static readonly string AppName = "REST with ASP.NET 10";
        public static readonly string AppDescription = "by samuel";

        public static WebApplication UseScalarConfiguration(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar", options =>
            {
                options
                .WithTitle(AppName)
                .WithOpenApiRoutePattern("/swagger/v1/swagger.json");
            });

            return app;
        }
    }
}

using Microsoft.OpenApi;

namespace rest_with_asp_net_10.Configuration
{
    public static class OpenApiConfig
    {
        public static readonly string AppName = "REST with ASP.NET 10";
        public static readonly string AppDescription = "by samuel";

        public static IServiceCollection AddOpenApiConfig(this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Samuel",
                    Url = new Uri("https://augustosamu.github.io/")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://augustosamu.github.io/")
                }
            });

            return services;
        }
    }
}

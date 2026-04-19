using Serilog;

namespace rest_with_asp_net_10.Configuration
{
    public static class LoggingConfig
    {
        public static void AddLoggingConfiguration(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}

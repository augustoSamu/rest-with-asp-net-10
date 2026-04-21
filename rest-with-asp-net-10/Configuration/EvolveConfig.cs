using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace rest_with_asp_net_10.Configuration
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveCondiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                return services;
            }

            var connectionString = configuration["ConnectionStrings:MSSQLServerConnection"];

            if (connectionString == null)
            {
                throw new ArgumentNullException("Connection string 'MSSQLServerConnection' not found in configuration.");
            }

            try
            {
                using var evolveConnection = new SqlConnection(connectionString);
                var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/seeds" },
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while applying database migrations");
                throw;
            }

            return services;
        }
    }
}

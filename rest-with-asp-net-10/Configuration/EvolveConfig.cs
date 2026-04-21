using Microsoft.Data.SqlClient;

namespace rest_with_asp_net_10.Configuration
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveCondiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
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
                using var evolve = new SqlConnection(connectionString);
                var evolve = new Evolve.Evolve(evolve, msg => Log.Information(msg))
                {
                    Locations = new[] { "db/migrations" },
                    IsEraseDisabled = true,
                };
            }
            catch (Exception ex) { }


            return services;
        }
    }
}

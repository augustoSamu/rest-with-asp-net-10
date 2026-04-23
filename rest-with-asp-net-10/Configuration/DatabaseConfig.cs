using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10.Context;

namespace rest_with_asp_net_10.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:MSSQLServerConnection"];

            if (connectionString == null)
            {
                throw new ArgumentNullException("Connection string 'MSSQLServerConnection' not found in configuration.");
            }

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}

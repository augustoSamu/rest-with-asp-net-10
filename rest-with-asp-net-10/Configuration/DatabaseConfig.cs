using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10.Model.Context;

namespace rest_with_asp_net_10.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionSting = configuration["ConnectionStrings:MSSQLServerConnection"];

            if (connectionSting == null)
            {
                throw new ArgumentNullException("Connection string 'MSSQLServerConnection' not found in configuration.");
            }

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionSting));
            return services;
        }
    }
}

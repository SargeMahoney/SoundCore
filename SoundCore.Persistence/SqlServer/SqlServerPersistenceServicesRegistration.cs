using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundCore.Application.Configurations.DatabaseSettings;

namespace SoundCore.Persistence.SqlServer
{
    public static class SqlServerPersistenceServicesRegistration
    {

        public static IServiceCollection AddSqlServerPersistenceServicesRegistraiton(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSetting>(configuration.GetSection("DatabaseConfiguration"));

            return services;
         
        }


    }
}

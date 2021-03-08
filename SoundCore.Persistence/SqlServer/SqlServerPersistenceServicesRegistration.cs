using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoundCore.Application.Configurations.DatabaseSettings;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Persistence.SqlServer.Repositories;

namespace SoundCore.Persistence.SqlServer
{
    public static class SqlServerPersistenceServicesRegistration
    {

        public static IServiceCollection AddSqlServerPersistenceServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSetting>(configuration.GetSection("DatabaseConfiguration"));
            services.AddSingleton<IDatabaseSetting>(sp => sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);

            services.AddTransient<IRoomsRepository, RoomsRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

            return services;
         
        }


    }
}

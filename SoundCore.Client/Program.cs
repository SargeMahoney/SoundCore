using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoundCore.Application;
using SoundCore.Application.Configurations.DatabaseSettings;
using SoundCore.Persistence.SqlServer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseConfiguration"));
            builder.Services.AddSingleton<IDatabaseSetting>(sp => sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);
            builder.Services.AddApplicationServices();
            builder.Services.AddSqlServerPersistenceServicesRegistration(builder.Configuration);
            //builder.Services.AddBlazorComponentsServices();
            //builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}

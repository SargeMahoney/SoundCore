using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SoundCore.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var StartAsService = true;

            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json")
                       .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + @"Log/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (StartAsService)
            {
                StartAspCoreAsService(args);
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                      .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }

        private static void StartAspCoreAsService(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            var pathToContentRoot = Directory.GetCurrentDirectory();
            var webHostArgs = args.Where(arg => arg != "--console").ToArray();
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }
            var host = WebHost.CreateDefaultBuilder(webHostArgs)
                       .UseSerilog()
               .UseContentRoot(pathToContentRoot)                 
               .UseStartup<Startup>()
               .Build();
            if (isService)
            {           
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundCore.Application.Contracts.Infrastructure;
using SoundCore.Infrastructure.Searcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServicesRegistration(this IServiceCollection services)
        {
        
            services.AddSingleton<ISearchService, SearchService>();

            return services;

        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using SoundCore.BlazorComponents.Features.Appointments.DataConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents
{
    public static class BlazorComponentsServicesRegistration
    {
        public static IServiceCollection AddBlazorComponentsServices(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentDataConverter, AppointmentDataConverter>();

            return services;
        }
    }
}

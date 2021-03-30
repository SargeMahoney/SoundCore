using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SoundCore.Application.Features.Rooms.Models;
using SoundCore.BlazorComponents.Features.Appointments.DataConverter;
using SoundCore.BlazorComponents.Features.Navigation.SideMenu.Services;
using SoundCore.BlazorComponents.Features.Rooms.Services;
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

            services.AddTransient<IRoomsManagementService, RoomsManagementService>();
            services.AddScoped<ISideMenuService, SideMenuService>();
         
            return services;
        }
    }
}

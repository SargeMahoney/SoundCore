﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SoundCore.Application.Features.Rooms.Models;
using System.Reflection;

namespace SoundCore.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

        

            return services;
        }
    }
}

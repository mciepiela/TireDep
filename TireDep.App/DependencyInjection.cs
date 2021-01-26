using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TireDep.App.Interfaces;
using TireDep.App.Services;

namespace TireDep.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddTransient<IDepositService, DepositService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}

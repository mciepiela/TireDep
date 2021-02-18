using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TireDep.App.Interfaces;
using TireDep.App.Services;
using TireDep.App.ViewModels.Deposit;
using TireDep.Domain.Model;

namespace TireDep.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddTransient<IDepositService, DepositService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Deposit), typeof(DepositVm));
            services.AddAutoMapper(typeof(DepositOwnerVm), typeof(Deposit));
            return services;

        }
    }
}

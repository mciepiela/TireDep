using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TireDep.Domain.Interfaces;
using TireDep.Infrastructure.Repo;

namespace TireDep.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDepositRepository, DepositRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            
            return services;
        }
    }
}

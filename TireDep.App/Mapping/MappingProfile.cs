﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using TireDep.App.ViewModels.Deposit;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Model;

namespace TireDep.App.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<Owner, NewOwnerVm>();
            CreateMap<Contact, NewOwnerVm>();
            CreateMap<Deposit, DepositDetailsVm>();
            CreateMap<Owner, DepositDetailsVm>();
            CreateMap<Contact, DepositDetailsVm>();
            CreateMap<Deposit, DepositDetVm>();
           

        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(t =>
                    t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}

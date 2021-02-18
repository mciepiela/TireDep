using System;
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
            //ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<Deposit, DepositVm>();
            CreateMap<Contact, ContactVm>();
            CreateMap<Owner, OwnerVm>();
            CreateMap<DepositOwnerVm, Deposit>();
            CreateMap<Deposit, DepositOwnerVm>();
            CreateMap<Deposit, DepositForListVm>();
            //CreateMap<Owner, DepositForListVm>();
            //CreateMap<SeasonTire, DepositForListVm>();
            CreateMap<SeasonTire, SeasonTypeForListVm>();//poprawić
            CreateMap<Owner, OwnerToListVm>();




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

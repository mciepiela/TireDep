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
            CreateMap<SeasonTire, SeasonTireVm>();
            CreateMap<Owner, OwnerVm>();
            CreateMap<DepositOwnerVm, Deposit>()
                .ForMember(d => d.SeasonTireId, o => o.MapFrom(s => s.Deposit.SeasonTireId))
                .ForMember(s => s.SeasonTire, o => o.Ignore());
                    
            CreateMap<Deposit, DepositOwnerVm>();
            CreateMap<Deposit, DepositForListVm>();
            //CreateMap<Owner, DepositForListVm>();
            //CreateMap<SeasonTire, DepositForListVm>();
            CreateMap<SeasonTire, SeasonTypeForListVm>();//poprawić
            CreateMap<Owner, OwnerToListVm>();
            //CreateMap<DepositOwnerVm, Deposit>()ForMember(d=>d.Owner);
            CreateMap<DepositOwnerVm, Owner>();
            CreateMap<DepositOwnerVm, SeasonTire>();
            CreateMap<DepositOwnerVm, Contact>();

            CreateMap<Domain.Model.Deposit, DepositForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight))
                .ForMember(d => d.SeasonTire, opt => opt.MapFrom(s => s.SeasonTire.Name))
                .ForMember(d => d.Owner, opt => opt.MapFrom(s => s.Owner.LastName + " " + s.Owner.FirstName));



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

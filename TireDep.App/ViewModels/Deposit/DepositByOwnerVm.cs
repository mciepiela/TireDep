using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositByOwnerVm : IMapFrom<Domain.Model.Deposit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTredHeight { get; set; }
        public string SeasonTire { get; set; }
        public bool IsActive { get; set; }
        public string OwnerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Deposit, DepositByOwnerVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TireTredHeight, opt => opt.MapFrom(src => src.TireTreadHeight))
                .ForMember(dest => dest.SeasonTire, opt => opt.MapFrom(src => src.SeasonTire.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.LastName + " " + src.Owner.FirstName));
        }

    }
}

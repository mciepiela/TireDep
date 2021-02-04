using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositDetailsVm : IMapFrom<Domain.Model.Deposit>, IMapFrom<Domain.Model.Owner>, IMapFrom<Domain.Model.Contact>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public string Owner { get; set; }
        public string Season { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
        public int? Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Deposit, DepositDetailsVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight))
                .ForMember(d => d.Season, opt => opt.MapFrom(s => s.SeasonTire.Name));
                
            profile.CreateMap<Domain.Model.Owner, DepositDetailsVm>()
                .ForMember(d => d.Owner, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName));
            profile.CreateMap<Domain.Model.Contact, DepositDetailsVm>()
                .ForMember(d => d.Tel, opt => opt.MapFrom(s => s.Tel))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email));
        }


    }
}

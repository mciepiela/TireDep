using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositDetailsVm : IMapFrom<Domain.Model.Deposit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public string SeasonTire { get; set; }
        
        public string Owner { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
        public int? Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Deposit, DepositDetailsVm>();

        }

        //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        //.ForMember(d => d.SeasonTire, opt => opt.MapFrom(s => s.SeasonTire.Name))
        //.ForMember(d => d.Owner, opt => opt.MapFrom(s =>  s.Owner.LastName))
        //.ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate))
        //.ForMember(s => s.EndDate, opt => opt.MapFrom(s => s.EndDate))
        //.ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive))
        //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
        //.ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight))
        //.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
    }
}

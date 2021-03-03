using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositOwnerVm : IMapFrom<Domain.Model.Deposit>
    {

        public DepositVm Deposit { get; set; }
        public OwnerVm Owner { get; set; }
        public ContactVm Contact { get; set; }
        public SeasonTireVm Season { get; set; }
        public static SelectList AllOwners { get; set; }
        public static SelectList TyreSeasonSelectList { get; set; }





        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Deposit, DepositOwnerVm>()
                .ForPath(d => d.Deposit.Id, opt => opt.MapFrom(s => s.Id))
                .ForPath(d => d.Deposit.Name, opt => opt.MapFrom(s => s.Name))
                .ForPath(d => d.Deposit.EndDate, opt => opt.MapFrom(s => s.EndDate))
                .ForPath(d => d.Deposit.StartDate, opt => opt.MapFrom(s => s.StartDate))
                .ForPath(d => d.Deposit.Price, opt => opt.MapFrom(s => s.Price))
                .ForPath(d => d.Deposit.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForPath(d => d.Deposit.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight))
                .ForPath(d => d.Deposit.OwnerId, opt => opt.MapFrom(s => s.OwnerId))
                .ForPath(d => d.Deposit.SeasonTireId, opt => opt.MapFrom(s => s.SeasonTireId));

            profile.CreateMap<DepositOwnerVm, Domain.Model.Deposit>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Deposit.Name))
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.Deposit.StartDate))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.Deposit.EndDate))
                .ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.Deposit.TireTreadHeight))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Deposit.Price))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Deposit.Id))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.Deposit.IsActive))
                .ForMember(d => d.OwnerId, opt => opt.MapFrom(s => s.Deposit.OwnerId))
                .ForMember(d => d.SeasonTireId, opt => opt.MapFrom(s => s.Deposit.SeasonTireId))
                .ForPath(d => d.SeasonTire.Id, opt => opt.MapFrom(s => s.Season.Id))
                .ForPath(d => d.SeasonTire.Name, opt => opt.MapFrom(s => s.Season.Name));



            //from owner i from contact


        }




    }

}

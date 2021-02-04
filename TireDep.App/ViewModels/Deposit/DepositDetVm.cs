using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositDetVm : IMapFrom<Domain.Model.Deposit>
    {
        //deposit
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }
        public string SeasonTire { get; set; }

        //owner
        public string OwnerFullName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerTel { get; set; }

        //$$$
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }



        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Domain.Model.Deposit, DepositDetVm>()
        //        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        //        .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
        //        .ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight))
        //        .ForMember(d => d.SeasonTire, opt => opt.MapFrom(s => s.SeasonTire.Name))
        //        .ForMember(d => d.OwnerFullName, opt => opt.MapFrom(s => s.Owner.LastName))
        //        .ForMember(d => d.OwnerEmail, opt => opt.MapFrom(s => s.Owner.Contact.Email))
        //        .ForMember(d => d.OwnerTel, opt => opt.MapFrom(s => s.Owner.Contact.Tel))
        //        .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate.Date))
        //        .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.EndDate.Value.Date))
        //        .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
            
        //}
    }


}

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class ContactVm : IMapFrom<Contact>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int OwnerRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactVm, Contact>().ReverseMap();
            profile.CreateMap<Domain.Model.Deposit, ContactVm>()
                .ForPath(d => d.Id, opt => opt.MapFrom(s => s.Owner.Contact.Id))
                .ForPath(d => d.Email, opt => opt.MapFrom(s => s.Owner.Contact.Email))
                .ForPath(d => d.Tel, opt => opt.MapFrom(s => s.Owner.Contact.Tel))
                .ForPath(d => d.OwnerRef, opt => opt.MapFrom(s => s.Owner.Contact.OwnerRef));
        }
    }
}

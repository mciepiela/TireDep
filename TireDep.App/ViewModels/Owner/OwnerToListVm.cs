using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Owner
{
    public class OwnerToListVm : IMapFrom<Domain.Model.Owner>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactInfo { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Owner, OwnerToListVm>()
                .ForMember(d => d.ContactInfo, opt => opt.MapFrom(s => s.Contact.Email))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.ContactInfo, opt => opt.MapFrom(s => s.Contact.Email));
        }
    }
}

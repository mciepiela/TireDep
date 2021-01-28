using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Owner
{
    public class NewOwnerVm : IMapFrom<Domain.Model.Owner>, IMapFrom<Contact>
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual ICollection<Domain.Model.Deposit> Deposit { get; set; }
        public Contact Contact { get; set; }



        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Owner, NewOwnerVm>().ReverseMap();
            //profile.CreateMap<Contact, NewContactVm>();
            //profile.CreateMap<Contact, NewOwnerVm>();
            //.ForPath(d => d.Contact.Email, opt => opt.MapFrom(s => s.Email))
            //.ForPath(d => d.Contact.Tel, opt => opt.MapFrom(s => s.Tel))
            //.ForPath(d => d.Contact.OwnerRef, opt => opt.MapFrom(s => s.OwnerRef))
            //.ForPath(d => d.Contact.Id, opt => opt.MapFrom(s => s.Id))
            //.ForPath(d => d.Contact.Owner, opt => opt.MapFrom(s => s.Owner));

        }
    }
}

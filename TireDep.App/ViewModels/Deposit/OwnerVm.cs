using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class OwnerVm : IMapFrom<Domain.Model.Owner>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactId { get; set; }
        //public int OwnerRef { get; set; }


        public class OwnerValidation : AbstractValidator<OwnerVm>
        {
            public OwnerValidation()
            {
                RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
                RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);

            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OwnerVm, Domain.Model.Owner>()
                .ReverseMap()
                //.ForMember(d=>d.OwnerRef, opt=>opt.MapFrom(s=>s.Id))
                .ForMember(d=>d.ContactId, opt=>opt.MapFrom(s=>s.Contact.Id));
            profile.CreateMap<OwnerVm, Domain.Model.Deposit>()
                .ForPath(d=>d.Owner.Id, opt=>opt.MapFrom(s=>s.Id))
                .ForPath(d => d.Owner.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForPath(d => d.Owner.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForPath(d => d.Owner.Contact, opt => opt.Ignore())
                .ForPath(d => d.Owner.Deposit, opt => opt.Ignore());
            profile.CreateMap<Domain.Model.Deposit, OwnerVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Owner.Id))
                .ForPath(d => d.FirstName, opt => opt.MapFrom(s => s.Owner.FirstName))
                .ForPath(d => d.LastName, opt => opt.MapFrom(s => s.Owner.LastName))
                .ForPath(d => d.ContactId, opt => opt.MapFrom(s => s.Owner.Contact.Id));
            
            profile.CreateMap<Domain.Model.Owner, OwnerVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForPath(d => d.ContactId, opt => opt.MapFrom(s => s.Contact.Id));

        }
    }
    
}

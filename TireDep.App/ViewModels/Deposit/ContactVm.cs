using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
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
        }

        public class ContactValidation : AbstractValidator<ContactVm>
        {
            public ContactValidation()
            {
                RuleFor(x => x.Tel).MinimumLength(9).MaximumLength(9).NotEmpty();
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.Id).NotNull();
            }
        }

    }

   
}

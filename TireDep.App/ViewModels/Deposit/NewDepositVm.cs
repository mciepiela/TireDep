//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Text;
//using AutoMapper;
//using FluentValidation;
//using FluentValidation.Validators;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using TireDep.App.Mapping;
//using TireDep.Domain.Model;

//namespace TireDep.App.ViewModels.Deposit
//{
//    public class NewDepositVm : IMapFrom<Domain.Model.Deposit>
//    {
//        public NewDepositVm()
//        {
//            SetActive();
//            SetStartDate();
//        }

//        [Required]
//        public int Id { get; set; }

//        [Required]
//        public string Name { get; set; }

//        [Required]
        
//        public int TireTreadHeight { get; set; }

//        //public SeasonTire SeasonTire { get; set; }
//        public int SeasonTireId { get; set; }
//        //public  Domain.Model.Owner Owner { get; set; }
//        public int OwnerId { get; set; }

//        [DataType(DataType.Date)]
//        public DateTime StartDate { get; set; }
//        [DataType(DataType.Date)]
//        public DateTime? EndDate { get; set; }

//        [DataType(DataType.Currency)]
//        public int? Price { get; set; }


//        public bool IsActive { get; set; }
//        //public virtual ICollection<Domain.Model.Owner> Owners { get; set; }
       
//        //public virtual ListOfSeasonTypeVm ListSeasonType { get; set; }

//        public static SelectList AllOwners { get; set; }
//        public static SelectList TyreSeasonSelectList { get; set; }



//        public class NewDepositValidation : AbstractValidator<NewDepositVm>
//        {
//            public NewDepositValidation()
//            {
//                RuleFor(v => v.Name).Length(3, 255).WithMessage("name");
//                RuleFor(v => v.TireTreadHeight).Cascade(CascadeMode.Stop).NotNull().LessThanOrEqualTo(10).GreaterThanOrEqualTo(0).WithMessage("bieżnik");
                

//                //RuleFor(v => v.Owner.FirstName).NotEmpty();
//                //RuleFor(v => v.Owner.LastName).NotEmpty();
//                //RuleFor(v => v.Owner.Contact.Email).Cascade(CascadeMode.Stop).NotEmpty()
//                //   .Matches(@"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)");
//                //RuleFor(v => v.Owner.Contact.Tel).Length(9);
//            }

//        }

//        //public static class CustomValidators
//        //{
//        //    public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
//        //    {
//        //        return ruleBuilder.SetValidator(new RegularExpressionValidator(@"[AZ][a-z]"));
//        //    }
//        //}
//        //
//        public void Mapping(Profile profile)
//        {
//            profile.CreateMap<NewDepositVm, Domain.Model.Deposit>()
//                .ReverseMap();
//            //.ForMember(d=>d.SeasonTire, opt =>opt.Ignore())
//            //.ForMember(d=>d.Owner, opt=>opt.Ignore());
//            // .ForPath(d => d.SeasonTire.Name, opt => opt.MapFrom(s => s.SeasonTire.Name))
//            // .ForPath(d => d.SeasonTire.Id, opt => opt.MapFrom(s => s.SeasonTire.Id))
//            // .ForPath(d => d.SeasonTire.Deposits, opt => opt.Ignore());
//            // .ForMember(d =>d.Owner, opt => opt.MapFrom(s=>s.Owner));

//        }


//        private void SetStartDate()
//        {
//            StartDate = DateTime.Now;
//        }

//        private void SetPriceAndEndDate()
//        {
//            EndDate = null;
//            Price = null;
//        }

//        private void SetActive()
//        {
//            IsActive = true;
//        }

        
//    }

   
//}

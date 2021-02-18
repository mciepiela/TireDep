using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositVm : IMapFrom<Domain.Model.Deposit>
    {
        public DepositVm()
        {
            SetActive();
            SetStartDate();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public int SeasonTireId { get; set; }
        
        public int OwnerId { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
        public double? Price { get; set; }

        private void SetStartDate()
        {
            StartDate = DateTime.Now;
        }

        private void SetPriceAndEndDate()
        {
            EndDate = null;
            Price = null;
        }

        private void SetActive()
        {
            IsActive = true;
        }
    


    public class DepositVmVal : AbstractValidator<DepositVm>
        {
            public void DepositVmtValidation()
            {
                RuleFor(v => v.Name).Length(3, 255).WithMessage("name");
                RuleFor(v => v.TireTreadHeight).Cascade(CascadeMode.Stop).NotNull().LessThanOrEqualTo(10).GreaterThanOrEqualTo(0).WithMessage("bieżnik");
            }

        }

 
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepositVm, Domain.Model.Deposit>()
                .ReverseMap();
        }
    }
}

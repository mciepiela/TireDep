using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class NewDepositVm : IMapFrom<Domain.Model.Deposit>
    {
        public NewDepositVm()
        {
            SetActive();
            SetStartDate();

            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public SeasonTire SeasonTire { get; set; }

        public  Domain.Model.Owner Owner { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }


        public bool IsActive { get; set; }
        public virtual ICollection<Domain.Model.Owner> Owners { get; set; }
        //public virtual ICollection<SeasonTire> SeasonTires { get; set; }
        public virtual ListOfSeasonTypeVm ListSeasonType { get; set; }

        public static SelectList TyreSeasonSelectList { get; set; }
        public string TyreSeasonId { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDepositVm, Domain.Model.Deposit>().ReverseMap();
            //.ForMember(d=>d.SeasonTire, opt=>opt.MapFrom(s=>s.SeasonTire))
            // .ForMember(d =>d.Owner, opt => opt.MapFrom(s=>s.Owner));

        }


        private void SetStartDate()
        {
            StartDate = DateTime.Now;
        }

        private void SetPriceAndEndDate()
        {
            EndDate = null;
        }

        private void SetActive()
        {
            IsActive = true;
        }

        
    }

   
}

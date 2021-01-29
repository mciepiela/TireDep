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
        public int SeasonTireId { get; set; }
        public  Domain.Model.Owner Owner { get; set; }
        public int OwnerId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Price { get; set; }


        public bool IsActive { get; set; }
        public virtual ICollection<Domain.Model.Owner> Owners { get; set; }
       
        public virtual ListOfSeasonTypeVm ListSeasonType { get; set; }

        public static SelectList AllOwners { get; set; }
        public static SelectList TyreSeasonSelectList { get; set; }
        



        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDepositVm, Domain.Model.Deposit>()
                .ReverseMap()
                .ForMember(d=>d.SeasonTire, opt =>opt.Ignore())
                .ForMember(d=>d.Owner, opt=>opt.Ignore());
               // .ForPath(d => d.SeasonTire.Name, opt => opt.MapFrom(s => s.SeasonTire.Name))
               // .ForPath(d => d.SeasonTire.Id, opt => opt.MapFrom(s => s.SeasonTire.Id))
               // .ForPath(d => d.SeasonTire.Deposits, opt => opt.Ignore());
            // .ForMember(d =>d.Owner, opt => opt.MapFrom(s=>s.Owner));

        }


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

        
    }

   
}

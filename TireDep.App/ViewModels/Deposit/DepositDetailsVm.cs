using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositDetailsVm : IMapFrom<Domain.Model.Deposit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public string SeasonTire { get; set; }
        
        public string Owner { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
        public int? Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Deposit, DepositDetailsVm>();

        }
    }
}

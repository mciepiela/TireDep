using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.App.Mapping;
using TireDep.Domain.Model;
using TireDep.RESTApi.Mapping;

namespace TireDep.RESTApi.Resources
{
    public class DepositResource : IMapFrom<Deposit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        //public string SeasonTire { get; set; }

        //public string Owner { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
        public double? Price { get; set; }

        public void Mapping(ModelToResourceProfile profile)
        {
            profile.CreateMap<Deposit, DepositResource>();
        }
    }
}

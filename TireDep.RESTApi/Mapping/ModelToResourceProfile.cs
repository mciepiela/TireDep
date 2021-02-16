using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TireDep.Domain.Model;
using TireDep.RESTApi.Resources;

namespace TireDep.RESTApi.Mapping
{
    public class ModelToResourceProfile :Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Deposit, DepositResource>();
            CreateMap<Owner, DepositResource>();
            CreateMap<SeasonTire, DepositResource>();
            CreateMap<Contact, DepositResource>();

        }
    }
}

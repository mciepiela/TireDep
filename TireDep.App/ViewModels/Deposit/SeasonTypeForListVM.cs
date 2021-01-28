using System;
using System.Collections.Generic;
using System.Text;
using TireDep.App.Mapping;
using TireDep.Domain.Model;
using AutoMapper;

namespace TireDep.App.ViewModels.Deposit
{
    public class SeasonTypeForListVm : IMapFrom<SeasonTire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeasonTypeForListVm, SeasonTire>().ReverseMap();
        }
    }

    
}

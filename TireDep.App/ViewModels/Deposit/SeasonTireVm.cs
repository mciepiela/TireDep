using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;


namespace TireDep.App.ViewModels.Deposit
{
    public class SeasonTireVm : IMapFrom<SeasonTire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeasonTire, SeasonTireVm>();

        }
    }
}

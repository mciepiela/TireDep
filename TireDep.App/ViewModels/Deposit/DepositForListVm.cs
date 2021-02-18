using System.Collections.Generic;
using AutoMapper;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositForListVm : IMapFrom<Domain.Model.Deposit>, IMapFrom<Domain.Model.Owner>, IMapFrom<SeasonTire>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }
        public string SeasonTire { get; set; }
        public int OwnerId { get; set; }
        public string Owner { get; set; }
       
        
        
        public void Mapping(Profile profile)
        {
            

            profile.CreateMap<Domain.Model.Deposit, DepositForListVm>().ReverseMap()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.TireTreadHeight, opt => opt.MapFrom(s => s.TireTreadHeight));
            //.ForPath(d => d.SeasonTire, opt => opt.MapFrom(s => s.SeasonTire.Name))
            // .ForPath(d => d.Owner, opt => opt.MapFrom(s => s.Owner.LastName + " "+ s.Owner.FirstName));
            profile.CreateMap<Domain.Model.Owner, DepositForListVm>()
                .ForPath(d => d.Owner, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName));
            profile.CreateMap<Domain.Model.SeasonTire, DepositForListVm>()
                .ForPath(d => d.SeasonTire, opt => opt.MapFrom(s => s.Name));
        }

    }
}

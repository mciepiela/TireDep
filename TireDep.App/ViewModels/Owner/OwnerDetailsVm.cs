using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TireDep.App.ViewModels.Owner
{
    public class OwnerDetailsVm
    {
        public List<ContactForListVm> ContactInf { get; set; }
        public List<DepositListByOwnerListForVm> ListOfAllDeposits { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Owner, OwnerDetailsVm>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using AutoMapper;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Interfaces;

namespace TireDep.App.Services
{
    class OwnerService : IOwnerService
    {

        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;

        }
        public OwnerDetailsSummaryVm AddNewOwnerForDeposit(NewOwnerVm newOwner)
        {
            OwnerDetailsSummaryVm newOwnerDet = new OwnerDetailsSummaryVm();
            newOwnerDet.Id = newOwner.Id;
            newOwnerDet.LastName = newOwner.LastName;

            return newOwnerDet;
        }

        public OwnerDetailsVm ViewOwnerById(int id)
        {
            throw new NotImplementedException();
        }

     
    }
}

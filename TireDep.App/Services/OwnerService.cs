using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;

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

        public int AddOwner(NewOwnerVm model)
        {
            var deposit = _mapper.Map<Owner>(model);
            var id = _ownerRepository.AddOwner(deposit);
            return id;
        }

        public ListForOwnerListVm GetAllOwners()
        {
            var list = _ownerRepository.GetAllOwners()
                .ProjectTo<OwnerToListVm>(_mapper.ConfigurationProvider).ToList();

            var ownerToList = new ListForOwnerListVm()
            {
                Owners = list,
                Count = list.Count
            };
            return ownerToList ;
        }
    }
}

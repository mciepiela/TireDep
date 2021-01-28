using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Deposit;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;

namespace TireDep.App.Services
{
    class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository; // przekazuje interfejs zamiast samego repository.
        private readonly IMapper _mapper; // interfejs automapera

        public DepositService(IDepositRepository depositRepository, IMapper mapper)
        {
            _depositRepository = depositRepository;
            _mapper = mapper;

        }

        public LisOfDepositsForListVm GetAllDepositForList(int pageSize, int pageNo, string searchString)
        {
            var deposits = _depositRepository.GetAllActiveDeposits()
                .Where(p => p.Name.Contains(searchString))
                .ProjectTo<DepositForListVm>(_mapper.ConfigurationProvider).ToList();

            var depositsToShow = deposits.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var depositList = new LisOfDepositsForListVm()
            {
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Deposits = depositsToShow,
                Count = deposits.Count
            };


            return depositList;
        }

        public int AddDeposit(NewDepositVm depositToAdd)
        {
            ///////// DOPISAC ARGUMENTY, MAPOWAC Z NEW DEPIST VM NA DEPOSIT
            var deposit = _mapper.Map<Deposit>(depositToAdd);

            var contact = new Contact()
            {
                Email = deposit.Owner.Contact.Email,
                //Id = deposit.Owner.Contact.Id,
                Owner = deposit.Owner,
                OwnerRef = deposit.OwnerId,
                Tel = deposit.Owner.Contact.Tel

            };
            var owner = new Owner()
            {
                Contact = contact,
                FirstName = deposit.Owner.FirstName,
                LastName = deposit.Owner.LastName,
            };

            var id = _depositRepository.AddDeposit(deposit, contact, owner);
            return id;
        }


        public DepositDetailsVm ViewDepositById(int depositId)
        {
            var deposit =_depositRepository.GetDepositById(depositId);
            var depositVm = _mapper.Map<DepositDetailsVm>(deposit);
            return depositVm;


        }

        public DepositListByOwnerListForVm ViewDepositsByOwnerId(int ownerId)
        {
            
            var deposits = _depositRepository.GetDepositByOwnerId(1)
                .ProjectTo<DepositByOwnerVm>(_mapper.ConfigurationProvider).ToList();

            DepositListByOwnerListForVm result = new DepositListByOwnerListForVm()
            {
                Count = deposits.Count,
                DepositByOwner = deposits
            };

            return result;
        }

        public DepositListByOwnerListForVm ViewDepositsByOwnerName(string piceOfName)
        {
            var deposits = _depositRepository.GetAllDepositsByPiceOfName(piceOfName)
                .ProjectTo<DepositByOwnerVm>(_mapper.ConfigurationProvider).ToList();

            DepositListByOwnerListForVm listOfDepositsByOwner = new DepositListByOwnerListForVm()
            {
                Count = deposits.Count,
                DepositByOwner = deposits
            };
            return listOfDepositsByOwner;
        }

        public ListOfSeasonTypeVm GetSeasonType()
        {
            var season = _depositRepository.GetAllSeasonTire().ProjectTo<SeasonTypeForListVm>(_mapper.ConfigurationProvider).ToList();

            ListOfSeasonTypeVm model = new ListOfSeasonTypeVm()
            {
                SeasonTypeList = season
                
            };
            return model;
        }
    }
}

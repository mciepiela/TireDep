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
            var deposit = _mapper.Map<Deposit>(depositToAdd);
            var id = _depositRepository.AddDeposit(deposit);
            return id;
        }


        //public DepositDetailsVm AddDeposit(NewDepositVm newDeposit)
        //{
        //    //Deposit depoDet = new Deposit();

        //    //depoDet.Id = newDeposit.Id;
        //    //depoDet.Name = newDeposit.Name;
        //    //depoDet.Owner.LastName = newDeposit.Owner.LastName;
        //    //depoDet.Owner.FirstName = newDeposit.Owner.FirstName;
        //    //depoDet.TireTreadHeight = newDeposit.TireTreadHeight;
        //    //depoDet.SeasonTire.Name = newDeposit.SeasonTire.Name;
        //    //depoDet.IsActive = true;
        //    //depoDet.StartDate = DateTime.Now;
          

        //    //DepositDetailsVm details = new DepositDetailsVm();
            
        //    //var depoVm = _depositRepository.AddDeposit(depoDet);
        //    //var depoDomain = _mapper.Map<Deposit>(depoVm);
        //    //return depoVm;


        //}

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
    }
}

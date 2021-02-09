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
        private readonly IOwnerRepository _ownerRepository;


        public DepositService(IDepositRepository depositRepository, IMapper mapper, IOwnerRepository ownerRepository)
        {
            _depositRepository = depositRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            

        }

        public LisOfDepositsForListVm GetAllDepositForList(int pageSize, int pageNo, string searchString, string searchStringOwnerName)
        {
            var deposits = _depositRepository.GetAllActiveDeposits()
                .Where(p => p.Name.Contains(searchString))
                .Where(d=>d.Owner.LastName.Contains(searchStringOwnerName) || d.Owner.FirstName.Contains(searchStringOwnerName))
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


        public DepositDetVm ViewDepositById(int id)
        {
            if(id != 0)
            {
                var deposit = _depositRepository.GetDepositById(id);
                Owner owner = _ownerRepository.GetOwner(deposit.OwnerId);
                var season = _depositRepository.GetSeason(deposit.SeasonTireId);
                var contact = _ownerRepository.GetContact(owner.Id);
                var depositVm = new DepositDetVm();
                {
                    depositVm.Id = deposit.Id;
                    depositVm.Name = deposit.Name;
                    depositVm.TireTreadHeight = deposit.TireTreadHeight;
                    depositVm.SeasonTire = season.Name;
                    depositVm.OwnerFullName = owner.LastName + " " + owner.FirstName;
                    depositVm.OwnerEmail = contact.Email;
                    depositVm.OwnerTel = contact.Tel;
                    depositVm.StartDate = deposit.StartDate.Date.ToString("d");
                    if (deposit.EndDate != null)
                    {
                        depositVm.EndDate = deposit.EndDate.Value.ToString("d");
                    };
                    if (deposit.Price != null)
                    {
                        depositVm.Price = deposit.Price.Value;
                    };


                }

                return depositVm;
            }
            else
            {
                // obejście błędu - nie istotne dla logii aplikacji
                DepositDetVm cm = new DepositDetVm();
                return cm;
            }
            

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

        public NewDepositVm GetDepositToEdit(int id)
        {
            var depositToEdit = _depositRepository.GetDepositById(id);
            var depositVm = _mapper.Map<NewDepositVm>(depositToEdit);
            return depositVm;

        }

        public void UpdateDeposit(NewDepositVm depostToEdit)
        {
            var deposit = _mapper.Map<Deposit>(depostToEdit);
            _depositRepository.UpdateDeposit(deposit);

        }




        public void ReturnDeposit(Deposit model)
        {
            model.EndDate = DateTime.Now;
            model.Price = CloseDeposit.CalculatePrice(model.StartDate, model.EndDate);
            model.IsActive = CloseDeposit.SetIsNoActive(model.IsActive);
            _depositRepository.UpdateDeposit(model);

        }

        public Deposit GetDepToReturn(int id)
        {
            var deposit = _depositRepository.GetDepositById(id);
            return deposit;
        }
    }
}

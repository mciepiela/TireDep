using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Deposit;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;

namespace TireDep.App.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository; 
        private readonly IMapper _mapper; 
        private readonly IOwnerRepository _ownerRepository;


        public DepositService(IDepositRepository depositRepository, IMapper mapper, IOwnerRepository ownerRepository)
        {
            _depositRepository = depositRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            

        }

        public LisOfDepositsForListVm GetAllDepositForList(int pageSize, int pageNo, string searchString, string searchStringOwnerName)
        {
            var countOfDeposits = _depositRepository.GetAllActiveDeposits().Count();
            var depositsToShow = _depositRepository.GetAllActiveDeposits()
                .Where(p => p.Name.Contains(searchString))
                .Where(d=>d.Owner.LastName.StartsWith(searchStringOwnerName) || d.Owner.FirstName.StartsWith(searchStringOwnerName))
                .ProjectTo<DepositForListVm>(_mapper.ConfigurationProvider)
                .Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

                //var depositsToShow = deposits.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var depositList = new LisOfDepositsForListVm()
            {
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Deposits = depositsToShow,
                Count = countOfDeposits,
                CountSearched = depositsToShow.Count
            };


            return depositList;
        }

        public LisOfDepositsForListVm GetAllDepositForList(string searchString, string searchStringOwnerName)
        {
            var depositsToShow = _depositRepository.GetAllActiveDeposits()
                .Where(p => p.Name.Contains(searchString))
                .Where(d => d.Owner.LastName.Contains(searchStringOwnerName) ||
                            d.Owner.FirstName.Contains(searchStringOwnerName))
                .ProjectTo<DepositForListVm>(_mapper.ConfigurationProvider).ToList();
            var depositList = new LisOfDepositsForListVm()
            {
                SearchString = searchString,
                Deposits = depositsToShow,
            
            };
            return depositList;
        }

        public int AddDeposit(DepositOwnerVm depositToAdd)
        {
          
           Deposit newDeposit = new Deposit();
         
           newDeposit.Name = depositToAdd.Deposit.Name;
           newDeposit.IsActive = depositToAdd.Deposit.IsActive;
           newDeposit.Price = depositToAdd.Deposit.Price;
           newDeposit.SeasonTireId = depositToAdd.Deposit.SeasonTireId;
           newDeposit.TireTreadHeight = depositToAdd.Deposit.TireTreadHeight;
           newDeposit.EndDate = depositToAdd.Deposit.EndDate;
           newDeposit.StartDate = depositToAdd.Deposit.StartDate;

      
           newDeposit.Owner = new Owner();
           newDeposit.Owner.LastName = depositToAdd.Owner.LastName;
           newDeposit.Owner.FirstName = depositToAdd.Owner.FirstName;
           newDeposit.Owner.Contact = new Contact();
           newDeposit.Owner.Contact.Email = depositToAdd.Contact.Email;
           newDeposit.Owner.Contact.Tel = depositToAdd.Contact.Tel;
           newDeposit.Owner.Contact.OwnerRef = depositToAdd.Contact.OwnerRef;

      
            var id = _depositRepository.AddDeposit(newDeposit);
            return id;
        }


        public DepositDetVm ViewDepositById(int id)
        {
            var deposit = _depositRepository.GetDepositById(id);
                var owner = _ownerRepository.GetOwner(deposit.OwnerId);
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

        public DepositOwnerVm GetDepositToEdit(int id)
        {
            var depositToEdit = _depositRepository.GetDepositById(id);
                var owner = depositToEdit.Owner;
                var contact = depositToEdit.Owner.Contact;
                var season = depositToEdit.SeasonTire;
         
                var depositVm = _mapper.Map<DepositOwnerVm>(depositToEdit);
                depositVm.Deposit = _mapper.Map<DepositVm>(depositToEdit);
                depositVm.Owner = _mapper.Map<OwnerVm>(depositToEdit.Owner);

                depositVm.Contact = _mapper.Map<ContactVm>(depositToEdit.Owner.Contact);
                depositVm.Season = _mapper.Map<SeasonTireVm>(depositToEdit.SeasonTire);

                return depositVm;
            
        }

        public void UpdateDeposit(DepositOwnerVm depostToEdit)
        {
            Deposit deposit = new Deposit();
            deposit.OwnerId = depostToEdit.Owner.Id;
            //deposit.Owner.Id = depostToEdit.Owner.Id;
            deposit.EndDate = depostToEdit.Deposit.EndDate;
            deposit.StartDate = depostToEdit.Deposit.StartDate;
            deposit.Id = depostToEdit.Deposit.Id;
            //deposit.Owner 
            deposit.IsActive = depostToEdit.Deposit.IsActive;
            deposit.Name = depostToEdit.Deposit.Name;
            deposit.Price = depostToEdit.Deposit.Price;
            deposit.SeasonTireId = depostToEdit.Season.Id;
            deposit.TireTreadHeight = depostToEdit.Deposit.TireTreadHeight;


            _depositRepository.UpdateDeposit(deposit);

        }




        public void ReturnDeposit(Deposit model)
        {
            model.EndDate = DateTime.Now;
            model.Price = CloseDeposit.CalculatePrice(model.StartDate, model.EndDate);
            model.IsActive = CloseDeposit.SetIsNoActive(model.IsActive);
            _depositRepository.UpdateDeposit(model);

        }

        public int AddDepositExistedUser(DepositOwnerVm depositToAdd)
        {
          
            Deposit newDeposit = new Deposit();
            
            newDeposit.Name = depositToAdd.Deposit.Name;
            newDeposit.IsActive = depositToAdd.Deposit.IsActive;
            newDeposit.Price = depositToAdd.Deposit.Price;
            newDeposit.SeasonTireId = depositToAdd.Deposit.SeasonTireId;
            newDeposit.TireTreadHeight = depositToAdd.Deposit.TireTreadHeight;
            newDeposit.EndDate = depositToAdd.Deposit.EndDate;
            newDeposit.StartDate = depositToAdd.Deposit.StartDate;
            newDeposit.OwnerId = depositToAdd.Deposit.OwnerId;

          
  
            var id = _depositRepository.AddDeposit(newDeposit);
            return id;
        }

        public SeasonTireVm GetSelectecSeason(int seasonId)
        {
            var seasonFromDb = _depositRepository.GetSeason(seasonId);
            var viewModel = _mapper.Map<SeasonTireVm>(seasonFromDb);
            return viewModel;
        }


        public Deposit GetDepToReturn(int id)
        {
            var deposit = _depositRepository.GetDepositById(id);
            return deposit;
        }

        
    }
}

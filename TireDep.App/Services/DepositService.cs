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

        public int AddDeposit(DepositOwnerVm depositToAdd)
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

        public DepositOwnerVm GetDepositToEdit(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("id nie może być równe 0");
            }
            else
            {
                var depositToEdit = _depositRepository.GetDepositById(id);
                var owner = _ownerRepository.GetOwner(depositToEdit.OwnerId);
                var conntact = _ownerRepository.GetContact(owner.Id);
                var season = _depositRepository.GetSeason(depositToEdit.SeasonTireId);
                
                
                DepositVm depositVm = new DepositVm()
                {
                    Id = depositToEdit.Id,
                    EndDate = depositToEdit.EndDate,
                    IsActive = depositToEdit.IsActive,
                    Name = depositToEdit.Name,
                    OwnerId = depositToEdit.OwnerId,
                    Price = depositToEdit.Price,
                    SeasonTireId = depositToEdit.SeasonTireId,
                    StartDate = depositToEdit.StartDate,
                    TireTreadHeight = depositToEdit.TireTreadHeight,
                };

                OwnerVm ownerVm = new OwnerVm()
                {
                    ContactId = owner.Contact.Id,
                    FirstName = owner.FirstName,
                    Id = owner.Id,
                    LastName = owner.LastName,
                };
                ContactVm contactVm = new ContactVm()
                {
                    Email = conntact.Email,
                    Tel = conntact.Tel,
                    Id = conntact.Id,
                    OwnerRef = conntact.OwnerRef,
                };
                SeasonTireVm seasonVm = new SeasonTireVm()
                {
                    Id = season.Id,
                    Name = season.Name,
                };
                
                DepositOwnerVm depositOwnerVm = new DepositOwnerVm()
                {
                   Deposit = depositVm,
                   Contact = contactVm,
                   Owner = ownerVm,
                   Season = seasonVm,
                };
                

                //var depositVm = _mapper.Map<DepositOwnerVm>(depositToEdit);
                //depositVm.Deposit = _mapper.Map<DepositVm>(depositToEdit);
                //depositVm.Owner = _mapper.Map<OwnerVm>(depositToEdit);

                //depositVm.Contact = _mapper.Map<ContactVm>(depositToEdit);
                // depositVm.Season = _mapper.Map<SeasonTireVm>(depositToEdit);

                return depositOwnerVm;
            }
        }

        public void UpdateDeposit(DepositOwnerVm depostToEdit)
        {
            
            var deposit = _mapper.Map<Deposit>(depostToEdit);
            //deposit.Owner = depostToEdit.
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

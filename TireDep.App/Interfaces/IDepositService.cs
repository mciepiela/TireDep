using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TireDep.App.ViewModels.Deposit;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Model;

namespace TireDep.App.Interfaces
{
    public interface IDepositService
    {
        LisOfDepositsForListVm GetAllDepositForList(int pageSize, int pageNo, string searchString, string searchStringOwnerName);
        LisOfDepositsForListVm GetAllDepositForList(string searchString, string searchStringOwnerName);
        int AddDeposit(DepositOwnerVm newDeposit);
        DepositDetVm ViewDepositById(int id);
        DepositListByOwnerListForVm ViewDepositsByOwnerId(int ownerId);
        //Task<DepositListByOwnerListForVm> GetListAsync(int ownerId);
        DepositListByOwnerListForVm ViewDepositsByOwnerName(string ownerName);

        ListOfSeasonTypeVm GetSeasonType();

        DepositOwnerVm GetDepositToEdit(int id);
        void UpdateDeposit(DepositOwnerVm depostToEdit);

        //DepositToReturnVm GetDepositToReturn(int id);
        Deposit GetDepToReturn(int id);
        //int UpdateDepositToReturn(DepositToReturnVm model);

        void ReturnDeposit(Deposit model);

        int AddDepositExistedUser(DepositOwnerVm depositToAdd);
        SeasonTireVm GetSelectecSeason(int seasonId);
    }
}

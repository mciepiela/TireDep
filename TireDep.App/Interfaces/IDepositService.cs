using System;
using System.Collections.Generic;
using System.Text;
using TireDep.App.ViewModels.Deposit;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Model;

namespace TireDep.App.Interfaces
{
    public interface IDepositService
    {
        LisOfDepositsForListVm GetAllDepositForList(int pageSize, int pageNo, string searchString);
        int AddDeposit(NewDepositVm newDeposit);
        DepositDetVm ViewDepositById(int depositId);
        DepositListByOwnerListForVm ViewDepositsByOwnerId(int ownerId);
        DepositListByOwnerListForVm ViewDepositsByOwnerName(string ownerName);

        ListOfSeasonTypeVm GetSeasonType();

        NewDepositVm GetDepositToEdit(int id);
        void UpdateDeposit(NewDepositVm depostToEdit);
    }
}

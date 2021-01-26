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
        LisOfDepositsForListVm GetAllDepositForList();
        DepositDetailsVm AddDeposit(NewDepositVm newDeposit);
        DepositDetailsVm ViewDepositById(int depositId);
        DepositListByOwnerListForVm ViewDepositsByOwnerId(int ownerId);

    }
}

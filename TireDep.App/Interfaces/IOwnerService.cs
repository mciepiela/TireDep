using System;
using System.Collections.Generic;
using System.Text;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Model;

namespace TireDep.App.Interfaces
{
    public interface IOwnerService
    {
        OwnerDetailsSummaryVm AddNewOwnerForDeposit(NewOwnerVm newOwner);
        OwnerDetailsVm ViewOwnerById(int id);

    }
}

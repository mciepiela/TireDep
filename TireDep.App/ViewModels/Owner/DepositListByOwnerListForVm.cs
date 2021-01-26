using System;
using System.Collections.Generic;
using System.Text;
using TireDep.App.ViewModels.Deposit;

namespace TireDep.App.ViewModels.Owner
{
    public class DepositListByOwnerListForVm
    {
        public List<DepositByOwnerVm> DepositByOwner { get; set; }
        public int Count { get; set; }
    }
}

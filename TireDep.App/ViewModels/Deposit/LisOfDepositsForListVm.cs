using System;
using System.Collections.Generic;
using System.Text;

namespace TireDep.App.ViewModels.Deposit
{
    public class LisOfDepositsForListVm
    {
        public List<DepositForListVm> Deposits { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchStringOwnerName { get; set; }
        public string SearchString { get; set; }

    }
}

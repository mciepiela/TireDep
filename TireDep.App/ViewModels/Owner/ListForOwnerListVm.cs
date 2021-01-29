using System;
using System.Collections.Generic;
using System.Text;

namespace TireDep.App.ViewModels.Owner
{
    public class ListForOwnerListVm
    {
        public IEnumerable<OwnerToListVm> Owners { get; set; }
        public int Count { get; set; }
    }
}

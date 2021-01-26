using System;
using System.Collections.Generic;
using System.Text;

namespace TireDep.App.ViewModels.Owner
{
    public class OwnerDetailsSummaryVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactForListVm> ContactInf { get; set; }
    }
}

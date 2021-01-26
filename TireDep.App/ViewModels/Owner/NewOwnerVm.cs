using System;
using System.Collections.Generic;
using System.Text;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Owner
{
    public class NewOwnerVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual ICollection<Domain.Model.Deposit> Deposit { get; set; }
        public Contact Contact { get; set; }
    }
}

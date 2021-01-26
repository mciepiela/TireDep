using System;
using System.Collections.Generic;
using System.Text;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class NewDepositVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }

        public SeasonTire SeasonTire { get; set; }

        public  Domain.Model.Owner Owner { get; set; }

        public DateTime StartDate { get; set; }
       

        public bool IsActive { get; set; }
        
    }
}

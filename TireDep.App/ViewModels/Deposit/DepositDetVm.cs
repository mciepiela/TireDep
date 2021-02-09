using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TireDep.App.Mapping;

namespace TireDep.App.ViewModels.Deposit
{
    public class DepositDetVm 
    {
        //deposit
        public int Id { get; set; }
        public string Name { get; set; }
        public int TireTreadHeight { get; set; }
        public string SeasonTire { get; set; }

        //owner
        public string OwnerFullName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerTel { get; set; }

        //$$$
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double? Price { get; set; }




    }


}

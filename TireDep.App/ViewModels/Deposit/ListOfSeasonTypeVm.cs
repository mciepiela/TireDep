using System;
using System.Collections.Generic;
using System.Text;
using TireDep.App.Mapping;
using TireDep.Domain.Model;

namespace TireDep.App.ViewModels.Deposit
{
    public class ListOfSeasonTypeVm : IMapFrom<SeasonTire>
    {
        public IEnumerable<SeasonTypeForListVm> SeasonTypeList { get; set; }
    }
    
}

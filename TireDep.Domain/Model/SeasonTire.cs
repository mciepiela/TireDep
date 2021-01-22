using System.Collections;
using System.Collections.Generic;

namespace TireDep.Domain.Model
{
    public class SeasonTire
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }

    }
}
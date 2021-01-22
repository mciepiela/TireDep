using System.Collections;
using System.Collections.Generic;

namespace TireDep.Domain.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Deposit> Deposit { get; set; }
        public Contact Contact { get; set; }

        // owner : contact relacja 1:1
    }
}
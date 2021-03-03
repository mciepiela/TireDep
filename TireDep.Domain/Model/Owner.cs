using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TireDep.Domain.Model
{
    public class Owner
    {
        public int Id { get; set; }

       // [Required]
        public string FirstName { get; set; }
        // [Required]
        public string LastName { get; set; }

        public virtual ICollection<Deposit> Deposit { get; set; }
        public virtual Contact Contact { get; set; }

        // owner : contact relacja 1:1
    }
}
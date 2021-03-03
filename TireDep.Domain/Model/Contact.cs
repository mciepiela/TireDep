using System.ComponentModel.DataAnnotations;

namespace TireDep.Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        //[Required]

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        //[Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(9), MinLength(9)]
        public string Tel { get; set; }
        public int OwnerRef { get; set; }
        public virtual Owner Owner { get; set; }

        // owner : contact relacja 1:1, dodatkowo
        // trzeba stworzyć klasę, która będzie przechowywać powiązanie
        // w context trzeba wskazać relacje FluentAPI
    }
}
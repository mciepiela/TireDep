using System.ComponentModel.DataAnnotations;

namespace TireDep.Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        //[Required]
        public string Email { get; set; }

        //[Required]
        [DataType(DataType.PhoneNumber)]

        public string Tel { get; set; }
        public int OwnerRef { get; set; }
        public Owner Owner { get; set; }
        // owner : contact relacja 1:1, dodatkowo
        // trzeba stworzyć klasę, która będzie przechowywać powiązanie
        // w context trzeba wskazać relacje FluentAPI
    }
}
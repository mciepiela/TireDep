namespace TireDep.Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int OwnerRef { get; set; }
        public Owner Owner { get; set; }
        // owner : contact relacja 1:1, dodatkowo
        // trzeba stworzyć klasę, która będzie przechowywać powiązanie
        // w context trzeba wskazać relacje FluentAPI
    }
}
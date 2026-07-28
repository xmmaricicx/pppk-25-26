namespace Pppk.WebApi.Models
{
    public class PatientAddress
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}

namespace Pppk.WebApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        public ICollection<PatientAddress> patientAddresses { get; set; }
        
    }
}

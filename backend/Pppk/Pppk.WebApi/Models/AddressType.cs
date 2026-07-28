namespace Pppk.WebApi.Models
{
    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PatientAddress> PatientAddresses { get; set; }
    }
}

namespace Pppk.WebApi.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}

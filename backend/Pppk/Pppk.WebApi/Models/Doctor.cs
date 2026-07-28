namespace Pppk.WebApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}

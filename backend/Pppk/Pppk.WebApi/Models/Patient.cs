using Pppk.WebApi.Models.Enums;

namespace Pppk.WebApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public ICollection<PatientAddress> PatientAddresses { get; set; }
        public ICollection<MedicalHistory> MedicalHistories { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
         
    }
}

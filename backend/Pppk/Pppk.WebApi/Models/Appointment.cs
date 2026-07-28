namespace Pppk.WebApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int ExaminationTypeId { get; set; }
        public ExaminationType ExaminationType { get; set; }

        public DateTime ScheduledAt { get; set; }
    }
}

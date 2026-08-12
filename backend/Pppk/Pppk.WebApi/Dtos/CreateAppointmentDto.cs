namespace Pppk.WebApi.Dtos
{
    public class CreateAppointmentDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ExaminationTypeId { get; set; }
        public DateTime ScheduledAt { get; set; }


    }
}

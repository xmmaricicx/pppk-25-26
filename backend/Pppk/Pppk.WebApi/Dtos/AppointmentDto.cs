namespace Pppk.WebApi.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string ExaminationTypeName { get; set; }
        public DateTime ScheduledAt { get; set; }
    }
}

using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Mappings
{
    public static class AppointmentMappings
    {
        public static AppointmentDto ToDto(this  Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
                DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
                ExaminationTypeName = appointment.ExaminationType.Name,
                ScheduledAt = appointment.ScheduledAt
            };
        }
    }
}

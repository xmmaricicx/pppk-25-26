using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Mappings
{
    public static class MedicalHistoryMappings
    {
        public static MedicalHistoryDto ToDto(this MedicalHistory history)
        {
            return new MedicalHistoryDto
            {
                Id = history.Id,
                PatientName = $"{history.Patient.FirstName} {history.Patient.LastName}",
                ConditionName = history.Condition.Name,
                StartDate = history.StartDate,
                EndDate = history.EndDate
            };
        }
    }
}

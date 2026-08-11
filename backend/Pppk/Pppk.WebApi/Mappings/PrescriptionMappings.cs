using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Mappings
{
    public static class PrescriptionMappings
    {
        public static PrescriptionDto ToDto(this Prescription prescription)
        {

            return new PrescriptionDto
            {
                Id = prescription.Id,
                PatientName = $"{prescription.Patient.FirstName} {prescription.Patient.LastName}",
                MedicationName = prescription.Medication.Name,
                ConditionName = prescription.Condition.Name,
                Dosage = prescription.Dosage,
                Frequency = prescription.Frequency
            };
        }
    }
}

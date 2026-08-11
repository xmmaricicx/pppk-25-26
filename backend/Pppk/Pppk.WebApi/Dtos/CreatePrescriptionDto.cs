namespace Pppk.WebApi.Dtos
{
    public class CreatePrescriptionDto
    {
        public int PatientId { get; set; }
        public int MedicationId { get; set; }
        public int ConditionId { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }

    }
}

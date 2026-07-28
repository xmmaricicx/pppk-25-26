namespace Pppk.WebApi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public int ConditionId { get; set; }
        public Condition Condition { get; set; }

        public string Dosage { get; set; }
        public string Frequency { get; set; }

    }
}

namespace Pppk.WebApi.Dtos
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string MedicationName { get; set; }
        public string ConditionName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
    }
}

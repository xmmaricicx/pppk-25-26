namespace Pppk.WebApi.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MedicalHistory> MedicalHistories { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }

    }
}

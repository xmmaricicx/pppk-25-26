namespace Pppk.WebApi.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

        public ICollection<SpecialtyExaminationType> SpecialtyExaminationTypes { get; set; }
    }
}

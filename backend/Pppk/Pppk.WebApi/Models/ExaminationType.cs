namespace Pppk.WebApi.Models
{
    public class ExaminationType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<SpecialtyExaminationType> SpecialtyExaminationTypes { get; set; }
    }
}

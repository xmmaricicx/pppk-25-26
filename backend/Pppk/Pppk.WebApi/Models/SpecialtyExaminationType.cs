namespace Pppk.WebApi.Models
{
    public class SpecialtyExaminationType
    {
        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public int ExaminationTypeId { get; set; }
        public ExaminationType ExaminationType { get; set; }
    }
}

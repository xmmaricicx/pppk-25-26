using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("specialty_examination_type")]
    public class SpecialtyExaminationType
    {

        [Column("specialty_id")]
        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        [Column("examination_type_id")]
        public int ExaminationTypeId { get; set; }
        public ExaminationType ExaminationType { get; set; }
    }
}

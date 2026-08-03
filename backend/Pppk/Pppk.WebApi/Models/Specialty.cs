using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("specialty")]
    public class Specialty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = [];

        public ICollection<SpecialtyExaminationType> SpecialtyExaminationTypes { get; set; } = [];
    }
}

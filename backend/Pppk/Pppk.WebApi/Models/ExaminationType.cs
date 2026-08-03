using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("examination_type")]
    public class ExaminationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<SpecialtyExaminationType> SpecialtyExaminationTypes { get; set; } = [];
    }
}

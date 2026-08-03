using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("doctor")]
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("specialty_id")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}

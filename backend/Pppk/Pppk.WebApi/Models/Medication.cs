using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("medication")]
    public class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = [];
    }
}

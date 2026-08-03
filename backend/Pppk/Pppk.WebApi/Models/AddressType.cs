using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("address_type")]
    public class AddressType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<PatientAddress> PatientAddresses { get; set; } = [];
    }
}

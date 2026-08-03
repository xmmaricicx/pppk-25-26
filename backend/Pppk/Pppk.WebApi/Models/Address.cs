using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("street")]
        [Required]
        [MaxLength(200)]
        public string Street { get; set; }

        [Column("house_number")]
        [Required]
        [MaxLength(20)]
        public string HouseNumber { get; set; }

        [Column("postal_code")]
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Column("post_id")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public ICollection<PatientAddress> PatientAddresses { get; set; } = [];
        
    }
}

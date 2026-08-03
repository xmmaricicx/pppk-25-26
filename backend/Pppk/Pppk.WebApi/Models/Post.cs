using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("postal_code")]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Column("city")]
        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        public ICollection<Address> Addresses { get; set; } = [];

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("patient_address")]
    public class PatientAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("address_type_id")]
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }

        [Column("address_id")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}

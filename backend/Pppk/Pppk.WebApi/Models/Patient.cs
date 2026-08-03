using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pppk.WebApi.Models.Enums;

namespace Pppk.WebApi.Models
{
    [Table("patient")]
    public class Patient
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

        [Column("oib")]
        [Required]
        [StringLength(11)]
        public string Oib { get; set; }

        [Column("date_of_birth")]
        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Column("gender")]
        public Gender Gender { get; set; }

        public ICollection<PatientAddress> PatientAddresses { get; set; } = [];
        public ICollection<MedicalHistory> MedicalHistories { get; set; } = [];
        public ICollection<Prescription> Prescriptions { get; set; } = [];
        public ICollection<Appointment> Appointments { get; set; } = [];
         
    }
}

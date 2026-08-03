using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("medication_id")]
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        [Column("condition_id")]
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }

        [Column("dosage")]
        [Required]
        [MaxLength(100)]
        public string Dosage { get; set; }

        [Column("frequency")]
        [Required]
        [MaxLength(100)]
        public string Frequency { get; set; }

    }
}

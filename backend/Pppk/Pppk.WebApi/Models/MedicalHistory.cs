using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("medical_history")]
    public class MedicalHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("condition_id")]
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }

        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        [Column("end_date")]
        public DateOnly? EndDate { get; set; }
    }
}

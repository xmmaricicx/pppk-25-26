using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pppk.WebApi.Models
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("examination_type_id")]
        public int ExaminationTypeId { get; set; }
        public ExaminationType ExaminationType { get; set; }

        [Column("scheduled_at")]
        public DateTime ScheduledAt { get; set; }
    }
}

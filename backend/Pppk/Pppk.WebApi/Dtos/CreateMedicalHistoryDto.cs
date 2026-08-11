namespace Pppk.WebApi.Dtos
{
    public class CreateMedicalHistoryDto
    {
        public int PatientId { get; set; }
        public int ConditionId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}

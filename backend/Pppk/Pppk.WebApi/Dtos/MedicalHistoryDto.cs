namespace Pppk.WebApi.Dtos
{
    public class MedicalHistoryDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string ConditionName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}

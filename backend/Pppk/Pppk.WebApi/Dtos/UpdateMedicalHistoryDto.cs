namespace Pppk.WebApi.Dtos
{
    public class UpdateMedicalHistoryDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}

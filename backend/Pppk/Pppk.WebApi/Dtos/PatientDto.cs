namespace Pppk.WebApi.Dtos
{
    public class PatientDto
    {     
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Domicile { get; set; }
        public string? Residence { get; set; }
    }
}

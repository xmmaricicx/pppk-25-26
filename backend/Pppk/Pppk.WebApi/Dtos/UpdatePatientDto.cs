using Pppk.WebApi.Models.Enums;

namespace Pppk.WebApi.Dtos
{
    public class UpdatePatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public CreateAddressDto Domicile { get; set; }
        public CreateAddressDto? Residence { get; set; }
    }
}

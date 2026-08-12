using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Mappings
{
    public static class DoctorMappings
    {
        public static DoctorDto ToDto(this Doctor doctor)
        {

            return new DoctorDto
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty.Name
            };
        }
    }
}

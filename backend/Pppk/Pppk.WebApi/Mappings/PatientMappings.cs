using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;
using Pppk.WebApi.UserExtensions;

namespace Pppk.WebApi.Mappings
{
    public static class PatientMappings
    {
        public static PatientDto ToDto(this Patient patient)
        {
            var residence = patient.PatientAddresses.FirstOrDefault(pa => pa.AddressType.Name == "Boravište");
            var domicile = patient.PatientAddresses.FirstOrDefault(pa => pa.AddressType.Name == "Prebivalište");

            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Oib = patient.Oib,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender.ToString(),
                Residence = residence != null ? residence.Address.ToFormatedString() : null,
                Domicile = domicile != null ? domicile.Address.ToFormatedString() : null
            };
        }


    }
}

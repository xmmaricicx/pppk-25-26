using Pppk.WebApi.Dtos;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Mappings
{
    public static class LookupMappings
    {
        public static SpecialtyDto ToDto(this Specialty s)
            => new() { Id = s.Id, Name = s.Name };

        public static ConditionDto ToDto(this Condition c)
            => new() { Id = c.Id, Name = c.Name };

        public static MedicationDto ToDto( this Medication m)
            => new() { Id = m.Id, Name = m.Name };

        public static AddressTypeDto ToDto(this AddressType at)
            => new() { Id = at.Id, Name = at.Name };

        public static PostDto ToDto(this Post p)
            => new() { Id = p.Id, City = p.City, PostalCode = p.PostalCode };

        public static ExaminationTypeDto ToDto( this ExaminationType et)
            => new() { Id = et.Id,Code = et.Code, Name = et.Name };
    }
}

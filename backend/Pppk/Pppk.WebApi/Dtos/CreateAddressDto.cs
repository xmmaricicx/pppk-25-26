using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Dtos
{
    public class CreateAddressDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public int PostId { get; set; }

    }
}

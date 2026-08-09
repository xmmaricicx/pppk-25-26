using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        private readonly HealthcareContext _context;
        public AddressTypesController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressType>>> GetAll()
        {

            var addressTypes = await _context.AddressTypes.ToListAsync();
            return Ok(addressTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specialty>> GetAsync(int id)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);
            return Ok(addressType);
        }
    }
}

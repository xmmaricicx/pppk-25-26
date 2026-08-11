using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public SpecialtiesController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetAll() {

            var specialties = await _context.Specialties.ToListAsync();
            return Ok(specialties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specialty>> GetById(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            return Ok(specialty);
        }
    }
}

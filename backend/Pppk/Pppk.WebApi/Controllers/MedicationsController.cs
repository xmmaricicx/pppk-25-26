using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly HealthcareContext _context;
        public MedicationsController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetAll()
        {

            var medications = await _context.Medications.ToListAsync();
            return Ok(medications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetById(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            return Ok(medication);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsController : ControllerBase
    {
        private readonly HealthcareContext _context;
        public ConditionsController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condition>>> GetAll()
        {

            var conditions = await _context.Conditions.ToListAsync();
            return Ok(conditions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Condition>> GetAsync(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);
            return Ok(condition);
        }
    }
}

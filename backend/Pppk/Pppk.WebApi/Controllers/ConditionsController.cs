using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
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
        public async Task<ActionResult<IEnumerable<ConditionDto>>> GetAll()
        {

            var conditions = await _context.Conditions.ToListAsync();
            var dto = conditions.Select(c => c.ToDto());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionDto>> GetById(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);
            var dto = condition.ToDto();

            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<ConditionDto>> Create(ConditionInputDto dto)
        {
            var condition = new Condition
            {
                Name = dto.Name
            };

            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = condition.Id }, condition.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ConditionInputDto dto)
        {
            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null) return NotFound();

            condition.Name = dto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null) return NotFound();

            _context.Conditions.Remove(condition);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

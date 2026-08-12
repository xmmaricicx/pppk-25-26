using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
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
        public async Task<ActionResult<IEnumerable<MedicationDto>>> GetAll()
        {

            var medications = await _context.Medications.ToListAsync();
            var dto = medications.Select(m => m.ToDto());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicationDto>> GetById(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            var dto = medication.ToDto();
            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<MedicationDto>> Create(MedicationInputDto dto)
        {
            var medication = new Medication
            {
                Name = dto.Name
            };

            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = medication.Id }, medication.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicationInputDto dto)
        {
            var medication = await _context.Medications.FindAsync(id);
            if (medication == null) return NotFound();

            medication.Name = dto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            if (medication == null) return NotFound();

            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

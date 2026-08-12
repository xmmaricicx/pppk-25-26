using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
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
        public async Task<ActionResult<IEnumerable<SpecialtyDto>>> GetAll() {

            var specialties = await _context.Specialties.ToListAsync();
            var dto = specialties.Select(s => s.ToDto());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDto>> GetById(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            var dto = specialty.ToDto();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<SpecialtyDto>> Create(SpecialtyInputDto dto)
        {
            var specialty = new Specialty
            {
                Name = dto.Name
            };

            _context.Specialties.Add(specialty);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = specialty.Id }, specialty.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SpecialtyInputDto dto)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null) return NotFound();

            specialty.Name = dto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null) return NotFound();

            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

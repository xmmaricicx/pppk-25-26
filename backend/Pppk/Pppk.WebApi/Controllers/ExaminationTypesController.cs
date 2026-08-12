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
    public class ExaminationTypesController : ControllerBase
    {
        private readonly HealthcareContext _context;
        public ExaminationTypesController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExaminationTypeDto>>> GetAll()
        {
            var examinationTypes = await _context.ExaminationTypes.ToListAsync();
            var dto = examinationTypes.Select(et => et.ToDto());

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExaminationTypeDto>> GetById(int id)
        {
            var examinationType = await _context.ExaminationTypes.FindAsync(id);
            var dto = examinationType.ToDto();
            
            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<ExaminationTypeDto>> Create(ExaminationTypeInputDto dto)
        {
            var examinationType = new ExaminationType
            {
                Name = dto.Name,
                Code = dto.Code
            };

            _context.ExaminationTypes.Add(examinationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = examinationType.Id }, examinationType.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExaminationTypeInputDto dto)
        {
            var examinationType = await _context.ExaminationTypes.FindAsync(id);
            if (examinationType == null) return NotFound();

            examinationType.Name = dto.Name;
            examinationType.Code = dto.Code;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var examinationType = await _context.ExaminationTypes.FindAsync(id);
            if (examinationType == null) return NotFound();

            _context.ExaminationTypes.Remove(examinationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

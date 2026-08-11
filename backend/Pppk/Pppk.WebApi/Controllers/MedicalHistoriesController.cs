using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoriesController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public MedicalHistoriesController(HealthcareContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalHistoryDto>>> GetAll()
        {
            var histories = await GetMedicalHistoryQuerry().ToListAsync();

            var dto = histories.Select(h => h.ToDto()).ToList();

            return Ok(dto);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistoryDto>> GetById(int id)
        {
            var history = await GetMedicalHistoryQuerry().FirstOrDefaultAsync(h => h.Id == id);

            if (history == null) return NotFound();
            
            var dto = history.ToDto();

            return Ok(dto);

        }



        [HttpPost]
        public async Task<ActionResult<MedicalHistoryDto>> Create(CreateMedicalHistoryDto dto)
        {
            var history = new MedicalHistory
            {
                PatientId = dto.PatientId,
                ConditionId = dto.ConditionId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            _context.MedicalHistories.Add(history);
            await _context.SaveChangesAsync();

            var created = await GetMedicalHistoryQuerry().FirstOrDefaultAsync(h => h.Id == history.Id);
            return CreatedAtAction(nameof(GetById), new { id = history.Id }, created.ToDto());
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMedicalHistoryDto dto)
        {
            var history = await _context.MedicalHistories.FindAsync(id);
            if (history == null) return NotFound();

            history.StartDate = dto.StartDate;
            history.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var history = await _context.MedicalHistories.FindAsync(id);
            if (history == null) return NotFound();

            _context.MedicalHistories.Remove(history);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }


        private IQueryable<MedicalHistory> GetMedicalHistoryQuerry()
        {
            return _context.MedicalHistories
                .Include(h => h.Patient)
                .Include(h => h.Condition);
        }
    }
}

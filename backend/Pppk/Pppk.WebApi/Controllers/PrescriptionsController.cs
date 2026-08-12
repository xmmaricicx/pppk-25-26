using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public PrescriptionsController(HealthcareContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetAll()
        {
            var prescriptions = await GetPrescriptionQuerry().ToListAsync();
            var dto = prescriptions.Select(pr => pr.ToDto());

            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDto>> GetById(int id)
        {
            var prescription = await GetPrescriptionQuerry().FirstOrDefaultAsync(pr => pr.Id == id);
            if (prescription == null) return NotFound();

            var dto = prescription.ToDto();
            return Ok(dto);

        }



        [HttpPost]
        public async Task<ActionResult<PrescriptionDto>> Create(CreatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                PatientId = dto.PatientId,
                MedicationId = dto.MedicationId,
                ConditionId = dto.ConditionId,
                Dosage = dto.Dosage,
                Frequency = dto.Frequency
            };

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            var created = await GetPrescriptionQuerry().FirstOrDefaultAsync(pr => pr.Id == prescription.Id);

            return CreatedAtAction(nameof(GetById), new {id= prescription.Id}, created.ToDto());
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePrescriptionDto dto)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if(prescription == null) return NotFound();

            prescription.Dosage = dto.Dosage;
            prescription.Frequency = dto.Frequency;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null) return NotFound();
            
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        private IQueryable<Prescription> GetPrescriptionQuerry()
        {
            return _context.Prescriptions
                .Include(pr => pr.Patient)
                .Include(pr => pr.Medication)
                .Include(pr => pr.Condition);
        }
    }
}

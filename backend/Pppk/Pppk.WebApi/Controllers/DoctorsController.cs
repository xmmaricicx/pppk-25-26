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
    public class DoctorsController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public DoctorsController(HealthcareContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {

            var doctors = await GetDoctorQuery().ToListAsync();
            var dto = doctors.Select(d => d.ToDto());

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await GetDoctorQuery().FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null) return NotFound();

            return Ok(doctor.ToDto());
        }

        [HttpGet("by-examination-type/{examinationTypeId}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetByExaminationTypeId(int examinationTypeId)
        {
            var doctors = await GetDoctorQuery()
                .Where(d => _context.SpecialtyExaminationTypes
                    .Any(se => se.ExaminationTypeId == examinationTypeId && se.SpecialtyId == d.SpecialtyId))
                .ToListAsync();

            var dto = doctors.Select(d => d.ToDto());
            return Ok(dto);
        }
        private IQueryable<Doctor> GetDoctorQuery()
        {
            return _context.Doctors.Include(d => d.Specialty);
        }

    }
}

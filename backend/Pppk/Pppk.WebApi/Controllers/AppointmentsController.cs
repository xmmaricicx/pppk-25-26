using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public AppointmentsController(HealthcareContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var appointments = await GetAppointmentQuery().ToListAsync();

            var dto = appointments.Select(a => a.ToDto());
            return Ok(dto);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetById(int id)
        {
            var appointment = await GetAppointmentQuery().FirstOrDefaultAsync(a => a.Id == id);
            if (appointment == null) return NotFound();

            var dto = appointment.ToDto();
            return Ok(dto);
        }



        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Create(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                ExaminationTypeId = dto.ExaminationTypeId,
                ScheduledAt = dto.ScheduledAt
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            var created = await GetAppointmentQuery().FirstOrDefaultAsync(a => a.Id == appointment.Id);
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, created.ToDto());
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            appointment.ScheduledAt = dto.ScheduledAt;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private IQueryable<Appointment> GetAppointmentQuery()
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.ExaminationType);
        }
    }
}

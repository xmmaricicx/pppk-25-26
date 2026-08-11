using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<ExaminationType>>> GetAll()
        {

            var examinationTypes = await _context.ExaminationTypes.ToListAsync();
            return Ok(examinationTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExaminationType>> GetById(int id)
        {
            var examinationType = await _context.ExaminationTypes.FindAsync(id);
            return Ok(examinationType);
        }
    }
}

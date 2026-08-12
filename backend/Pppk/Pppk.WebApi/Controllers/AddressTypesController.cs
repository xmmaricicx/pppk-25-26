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
    public class AddressTypesController : ControllerBase
    {
        private readonly HealthcareContext _context;
        public AddressTypesController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressTypeDto>>> GetAll()
        {

            var addressTypes = await _context.AddressTypes.ToListAsync();
            var dto = addressTypes.Select(at => at.ToDto());
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressTypeDto>> GetById(int id)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);
            var dto = addressType.ToDto();

            return Ok(dto);
        }



        [HttpPost]
        public async Task<ActionResult<AddressTypeDto>> Create(AddressTypeInputDto dto)
        {
            var addressType = new AddressType
            {
                Name = dto.Name
            };

            _context.AddressTypes.Add(addressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = addressType.Id }, addressType.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressTypeInputDto dto)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);
            if (addressType == null) return NotFound();

            addressType.Name = dto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);
            if (addressType == null) return NotFound();

            _context.AddressTypes.Remove(addressType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

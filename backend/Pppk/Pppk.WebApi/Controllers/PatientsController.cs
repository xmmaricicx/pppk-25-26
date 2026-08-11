using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
using Pppk.WebApi.Models;


namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public PatientsController(HealthcareContext context)
        {
            _context = context;
        }


        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await GetPatientWithAddresessQuerry().ToListAsync();
            
            var dto = patients.Select(p => p.ToDto());

            return Ok(dto);
        }


        
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await GetPatientWithAddresessQuerry().FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null) return NotFound();

            var dto = patient.ToDto();

            return Ok(dto);

        }


        
        [HttpPost]
        public async Task<ActionResult<PatientDto>> Create(CreatePatientDto dto)
        {
            var domicileType = await _context.AddressTypes.FirstAsync(at => at.Name == "Prebivalište");
            var residenceType = await _context.AddressTypes.FirstAsync(at => at.Name == "Boravište");

            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Oib = dto.Oib,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PatientAddresses = new List<PatientAddress>{
                    new PatientAddress
                    {
                        AddressTypeId = domicileType.Id,
                        Address = new Address
                        {
                            Street = dto.Domicile.Street,
                            HouseNumber = dto.Domicile.HouseNumber,
                            PostId = dto.Domicile.PostId,
                            PostalCode = dto.Domicile.PostalCode
                        }
                    }
                }
            };
            if (dto.Residence != null)
            {
                patient.PatientAddresses.Add(new PatientAddress
                {
                    AddressTypeId = residenceType.Id,
                    Address = new Address
                    {
                        Street = dto.Residence.Street,
                        HouseNumber = dto.Residence.HouseNumber,
                        PostId = dto.Residence.PostId,
                        PostalCode = dto.Residence.PostalCode
                    }
                });
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var created = await GetPatientWithAddresessQuerry().FirstOrDefaultAsync(p => p.Id == patient.Id);

            return CreatedAtAction(nameof(GetById), new { patient.Id }, created.ToDto());
        }



        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto dto)
        {
            var patient = await GetPatientWithAddresessQuerry().FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null) return NotFound();

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.DateOfBirth = dto.DateOfBirth;
            patient.Gender = dto.Gender;


            var domicile = patient.PatientAddresses.FirstOrDefault(pa => pa.AddressType.Name == "Prebivalište");
            if (domicile != null)
            {
                domicile.Address.Street = dto.Domicile.Street;
                domicile.Address.HouseNumber = dto.Domicile.HouseNumber;
                domicile.Address.PostId = dto.Domicile.PostId;
            }

            if (dto.Residence != null)
            {
                var residence = patient.PatientAddresses.FirstOrDefault(pa => pa.AddressType.Name == "Boravište");
                if (residence != null)
                {
                    residence.Address.Street = dto.Residence.Street;
                    residence.Address.HouseNumber = dto.Residence.HouseNumber;
                    residence.Address.PostId = dto.Residence.PostId;
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null) return NotFound();

            _context.Patients.Remove(existingPatient);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private  IQueryable<Patient> GetPatientWithAddresessQuerry()
        {
            return _context.Patients
              .Include(p => p.PatientAddresses)
                  .ThenInclude(pa => pa.Address)
                  .ThenInclude(a => a.Post)
              .Include(p => p.PatientAddresses)
                  .ThenInclude(pa => pa.AddressType);
        }
    }
}

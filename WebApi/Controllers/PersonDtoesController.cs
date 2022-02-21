using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timesheets.Api.Data;
using Timesheets.BusinessLayer.Dto;

namespace Timesheets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDtoesController : ControllerBase
    {
        private readonly TimesheetsApiContext _context;

        public PersonDtoesController(TimesheetsApiContext context)
        {
            _context = context;
        }

        // GET: api/PersonDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersonDto()
        {
            return await _context.PersonDto.ToListAsync();
        }

        // GET: api/PersonDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPersonDto(int id)
        {
            var personDto = await _context.PersonDto.FindAsync(id);

            if (personDto == null)
            {
                return NotFound();
            }

            return personDto;
        }

        // PUT: api/PersonDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonDto(int id, PersonDto personDto)
        {
            if (id != personDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(personDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPersonDto(PersonDto personDto)
        {
            _context.PersonDto.Add(personDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonDto", new { id = personDto.Id }, personDto);
        }

        // DELETE: api/PersonDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonDto(int id)
        {
            var personDto = await _context.PersonDto.FindAsync(id);
            if (personDto == null)
            {
                return NotFound();
            }

            _context.PersonDto.Remove(personDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonDtoExists(int id)
        {
            return _context.PersonDto.Any(e => e.Id == id);
        }
    }
}

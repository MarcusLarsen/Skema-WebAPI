using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.Models;
using Mapster;
using Skema_WebAPI.DTO;

namespace Skema_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly SkemaDbContext _context;

        public DaysController(SkemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayDTO>>> GetDay()
        {
            var days = await _context.Day.ToListAsync();

            // Map the list of Day entities to DayDTOs
            var dayDtos = days.Adapt<List<DayDTO>>();

            return Ok(dayDtos);
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayDTO>> GetDay(int id)
        {
            var day = await _context.Day.FindAsync(id);

            if (day == null)
            {
                return NotFound();
            }

            // Map the Day entity to a DayDTO
            var dayDto = day.Adapt<DayDTO>();

            return Ok(dayDto);
        }

        // PUT: api/Days/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(int id, DayDTO dayDto)
        {
            if (id != dayDto.DayId)
            {
                return BadRequest();
            }

            // Map the DayDTO back to a Day entity
            var day = dayDto.Adapt<Day>();

            _context.Entry(day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
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

        // POST: api/Days
        [HttpPost]
        public async Task<ActionResult<DayForSaveDTO>> PostDay(DayForSaveDTO dayDto)
        {
            // Map the DayDTO to a Day entity
            var day = dayDto.Adapt<Day>();

            day.Name = dayDto.Dato.DayOfWeek.ToString();

            _context.Day.Add(day);
            await _context.SaveChangesAsync();

            // Map the saved Day entity back to a DayDTO
            var savedDayDto = day.Adapt<DayDTO>();

            return CreatedAtAction("GetDay", new { id = savedDayDto.DayId }, savedDayDto);
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            var day = await _context.Day.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            _context.Day.Remove(day);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayExists(int id)
        {
            return _context.Day.Any(e => e.DayId == id);
        }
    }

}

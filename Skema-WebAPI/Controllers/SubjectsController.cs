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
    public class SubjectsController : ControllerBase
    {
        private readonly SkemaDbContext _context;

        public SubjectsController(SkemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubject()
        {
            return await _context.Subject.ToListAsync();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _context.Subject.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<SubjectDTO>> PostSubject(SubjectForSaveDTO subjectDto)
        {
            /*var teacherExists = await _context.Teachers.AnyAsync(t => t.TeacherId == subjectDto.TeacherId);
            if (!teacherExists)
            {
                return BadRequest($"Teacher with ID {subjectDto.TeacherId} does not exist.");
            }

            if (subjectDto.DayIds != null && subjectDto.DayIds.Any())
            {
                var invalidDayIds = subjectDto.DayIds
                    .Where(dayId => !_context.Day.Any(d => d.DayId == dayId))
                    .ToList();

                if (invalidDayIds.Any())
                {
                    return BadRequest($"The following Day IDs are invalid: {string.Join(", ", invalidDayIds)}");
                }
            }

            var subject = subjectDto.Adapt<Subject>();
            subject.Teacher = await _context.Teachers.FindAsync(subjectDto.TeacherId);

            if (subjectDto.DayIds != null && subjectDto.DayIds.Any())
            {
                subject.Days = await _context.Day
                    .Where(d => subjectDto.DayIds.Contains(d.DayId))
                    .ToListAsync();
            }

            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();
            var savedSubjectDto = subject.Adapt<SubjectDTO>();

            return CreatedAtAction("GetSubject", new { id = savedSubjectDto.SubjectId }, savedSubjectDto);
        }*/

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.SubjectId == id);
        }
    }
}

using Mapster;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly SkemaDbContext _context;
        public SubjectService(SkemaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubjectDTO>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subject.ToListAsync();
            return subjects.Adapt<IEnumerable<SubjectDTO>>();
        }
        public async Task<SubjectDTO> GetSubjectByIdAsync(int subjectId)
        {
            var day = await _context.Subject.FindAsync(subjectId);
            return day.Adapt<SubjectDTO>();
        }

        public async Task<SubjectDTO> AddSubjectAsync(SubjectDTO subjectDto)
        {
            var subject = subjectDto.Adapt<Subject>();
            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();
            return subject.Adapt<SubjectDTO>();
        }

        public async Task<bool> DeleteSubjectAsync(int subjectId)
        {
            var subject = await _context.Subject.FindAsync(subjectId);
            if (subject == null) return false;

            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

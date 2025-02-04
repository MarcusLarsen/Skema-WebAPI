using Mapster;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly SkemaDbContext _context;
        public TeacherService(SkemaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return teachers.Adapt<IEnumerable<TeacherDTO>>();
        }
        public async Task<TeacherDTO> GetTeacherByIdAsync(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            return teacher.Adapt<TeacherDTO>();
        }

        public async Task<TeacherDTO> AddTeacherAsync(TeacherDTO teacherDto)
        {
            var teacher = teacherDto.Adapt<Teacher>();
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher.Adapt<TeacherDTO>();
        }

        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

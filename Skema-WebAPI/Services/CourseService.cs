using Mapster;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Services
{
    public class CourseService : ICourseService
    {

        private readonly SkemaDbContext _context;

        public CourseService(SkemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses.Adapt<IEnumerable<CourseDTO>>();
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            return course.Adapt<CourseDTO>();
        }

        public async Task<CourseDTO> AddCourseAsync(CourseDTO courseDto)
        {
            var course = courseDto.Adapt<Course>();
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course.Adapt<CourseDTO>();
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

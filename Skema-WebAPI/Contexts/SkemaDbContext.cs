using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Contexts
{
    public class SkemaDbContext : IdentityDbContext<Skema_WebAPI.Models.User>
    {
        public SkemaDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Day> Day { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DaySubject> DaySubjects { get; set; }
        public DbSet<DayTeacher> DayTeachers { get; set; }
        public DbSet<TeacherCourse> TeachersCourses { get; set; }
    }
}

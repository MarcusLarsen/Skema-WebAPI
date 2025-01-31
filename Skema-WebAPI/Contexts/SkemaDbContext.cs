using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Contexts
{
    public class SkemaDbContext : DbContext
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
        public DbSet<TeacherCourse> TeachersCourse { get; set; }

    }
}

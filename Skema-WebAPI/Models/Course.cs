namespace Skema_WebAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string CourseName { get; set; }
        
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}

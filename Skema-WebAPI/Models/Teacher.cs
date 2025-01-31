namespace Skema_WebAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string Name { get; set; }

        public ICollection<DayTeacher>? DayTeachers { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
    }
}

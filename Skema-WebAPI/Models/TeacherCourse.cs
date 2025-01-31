using System.ComponentModel.DataAnnotations.Schema;

namespace Skema_WebAPI.Models
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
    }
}

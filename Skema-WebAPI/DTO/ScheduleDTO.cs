namespace Skema_WebAPI.DTO
{
    public class ScheduleDTO 
    {
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public List<SubjectDTO> Subjects { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}
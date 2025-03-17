using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;

        public ScheduleService(ICourseService courseService, ITeacherService teacherService, ISubjectService subjectService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
            _subjectService = subjectService;
        }

        public async Task<ScheduleDTO> CreateScheduleAsync(ScheduleDTO scheduleDto)
        {
            int courseId = int.Parse(scheduleDto.CourseName); 
            int teacherId = int.Parse(scheduleDto.TeacherName); 

            var course = await _courseService.GetCourseByIdAsync(courseId);
            var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
            var subjects = await _subjectService.GetAllSubjectsAsync();

            if (course == null || teacher == null)
            {
                throw new InvalidOperationException("Course or Teacher not found.");
            }
            return scheduleDto;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetSchedulesByCourseAsync(string courseName)
        {
            return new List<ScheduleDTO>();
        }
    }
}

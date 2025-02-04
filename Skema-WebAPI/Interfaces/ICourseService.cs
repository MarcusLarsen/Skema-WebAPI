using Skema_WebAPI.DTO;

namespace Skema_WebAPI.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int courseId);
        Task<CourseDTO> AddCourseAsync(CourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}

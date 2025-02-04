using Skema_WebAPI.DTO;

namespace Skema_WebAPI.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync();
        Task<TeacherDTO> GetTeacherByIdAsync(int teacherId);
        Task<TeacherDTO> AddTeacherAsync(TeacherDTO teacherDto);
        Task<bool> DeleteTeacherAsync(int teacherId);
    }
}

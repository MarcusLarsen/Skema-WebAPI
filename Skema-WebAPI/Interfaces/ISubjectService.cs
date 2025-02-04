using Skema_WebAPI.DTO;

namespace Skema_WebAPI.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDTO>> GetAllSubjectsAsync();
        Task<SubjectDTO> GetSubjectByIdAsync(int subjectId);
        Task<SubjectDTO> AddSubjectAsync(SubjectDTO subjectDto);
        Task<bool> DeleteSubjectAsync(int subjectId);
    }
}

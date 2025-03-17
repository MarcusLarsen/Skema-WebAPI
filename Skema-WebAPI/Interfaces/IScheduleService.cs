using Skema_WebAPI.DTO;

namespace Skema_WebAPI.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> CreateScheduleAsync(ScheduleDTO scheduleDto);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByCourseAsync(string courseName);
    }
}

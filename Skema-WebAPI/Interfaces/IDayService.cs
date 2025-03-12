using Skema_WebAPI.DTO;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Interfaces
{
    public interface IDayService
    {
        Task<IEnumerable<DayDTO>> GetAllDaysAsync();
        Task<DayDTO> GetDayByIdAsync(int dayId);
        Task<DayDTO> AddDayAsync(DayDTO dayDto);
        Task<bool> DeleteDayAsync(int dayId);
        Task<IEnumerable<DayDTO>> GetScheduleByCourseAsync(string course);
    }
}

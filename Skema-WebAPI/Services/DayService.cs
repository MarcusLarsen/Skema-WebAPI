using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Services
{
    public class DayService : IDayService
    {
        private readonly SkemaDbContext _context;

        public DayService(SkemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayDTO>> GetAllDaysAsync()
        {
            var days = await _context.Day.ToListAsync();
            return days.Adapt<IEnumerable<DayDTO>>();
        }

        public async Task<DayDTO> GetDayByIdAsync(int dayId)
        {
            var day = await _context.Day.FindAsync(dayId);
            return day.Adapt<DayDTO>();
        }

        public async Task<DayDTO> AddDayAsync(DayDTO dayDto)
        {
            var day = dayDto.Adapt<Day>();
            _context.Day.Add(day);
            await _context.SaveChangesAsync();
            return day.Adapt<DayDTO>();
        }

        public async Task<bool> DeleteDayAsync(int dayId)
        {
            var day = await _context.Day.FindAsync(dayId);
            if (day == null) return false;

            _context.Day.Remove(day);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

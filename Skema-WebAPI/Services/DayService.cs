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
        public async Task<IEnumerable<DayDTO>> GetScheduleByCourseAsync(string course)
        {
            var schedule = await _context.Day
                .Where(d => d.Course.CourseName == course)
                .ToListAsync();

            if (schedule == null || !schedule.Any())
            {
                // Return mock data hvis der ikke findes noget i databasen
                return GetMockSchedule(course);
            }

            return schedule.Select(d => d.Adapt<DayDTO>());
        }

        // Flyt denne metode til din service eller en helper-klasse
        private IEnumerable<DayDTO> GetMockSchedule(string course)
        {
            var mockSchedule = new List<DayDTO>();

            if (course == "H1")
            {
                mockSchedule.Add(new DayDTO
                {
                    Dato = DateTime.UtcNow,
                    Subjects = new List<SubjectForSaveDTO>
            {
                new SubjectDTO { Name = "Mathematics", StartDate = DateTime.Parse("2025-03-17T08:00:00"), EndDate = DateTime.Parse("2025-03-17T10:00:00") },
                new SubjectDTO { Name = "Physics", StartDate = DateTime.Parse("2025-03-17T10:30:00"), EndDate = DateTime.Parse("2025-03-17T12:00:00") }
            }
                });
            }

            return mockSchedule;
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

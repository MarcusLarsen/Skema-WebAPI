using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.Models;
using Mapster;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;
using Skema_WebAPI.Services;

namespace Skema_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly IDayService _dayservice;

        public DaysController(IDayService dayService)
        {
            _dayservice = dayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDays()
        {
            var days = await _dayservice.GetAllDaysAsync();
            return Ok(days);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDayById(int dayId)
        {
            var day = await _dayservice.GetDayByIdAsync(dayId);
            if (day == null) return NotFound();
            return Ok(day);
        }

        [HttpGet("schedule")]
        public async Task<IActionResult> GetScheduleByCourse([FromQuery] string course)
        {
            if (string.IsNullOrEmpty(course)) return BadRequest("Course name is required.");

            // For test purposes, if no course is found in the service, we'll return mock data
            var schedule = await _dayservice.GetScheduleByCourseAsync(course);

            if (schedule == null)
            {
                // Return mock data if no schedule found
                schedule = GetMockSchedule(course);
                if (schedule == null)
                {
                    return NotFound("No schedule found for this course.");
                }
            }

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> AddDay([FromBody] DayDTO dayDto)
        {
            if (dayDto == null) return BadRequest();
            var createdDay = await _dayservice.AddDayAsync(dayDto);
            return CreatedAtAction(nameof(GetDayById), new { id = createdDay.DayId });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int dayId)
        {
            var result = await _dayservice.DeleteDayAsync(dayId);
            if (!result) return NotFound();
            return Ok("Day Has Been Deleted Successfully");
        }

        // Mock data for testing purposes, returns List<DayDTO> instead of object
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
            else if (course == "H2")
            {
                mockSchedule.Add(new DayDTO
                {
                    Dato = DateTime.UtcNow,
                    Subjects = new List<SubjectForSaveDTO>
            {
                new SubjectDTO { Name = "Chemistry", StartDate = DateTime.Parse("2025-03-18T09:00:00"), EndDate = DateTime.Parse("2025-03-18T11:00:00") },
                new SubjectDTO { Name = "Biology", StartDate = DateTime.Parse("2025-03-18T11:30:00"), EndDate = DateTime.Parse("2025-03-18T13:00:00") }
            }
                });
            }

            // Sørg for, at der altid returneres en værdi
            return mockSchedule;
        }
    }
 }



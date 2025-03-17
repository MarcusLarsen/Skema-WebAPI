using Microsoft.AspNetCore.Mvc;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;

namespace Skema_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/Schedules/courseName
        [HttpGet("{courseName}")]
        public async Task<IActionResult> GetSchedulesByCourse(string courseName)
        {
            var schedules = await _scheduleService.GetSchedulesByCourseAsync(courseName);
            if (schedules == null || !schedules.Any()) return NotFound("No schedules found for this course.");
            return Ok(schedules);
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleDTO scheduleDto)
        {
            if (scheduleDto == null) return BadRequest("Invalid schedule data.");

            var createdSchedule = await _scheduleService.CreateScheduleAsync(scheduleDto);
            return CreatedAtAction(nameof(GetSchedulesByCourse), new { courseName = createdSchedule.CourseName }, createdSchedule);
        }
    }
}


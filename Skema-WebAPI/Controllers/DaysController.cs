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

        [HttpPost]
        public async Task<IActionResult> AddDay([FromBody] DayDTO dayDto)
        {
            if (dayDto == null) return BadRequest();
            var createdDay = await _dayservice.AddDayAsync(dayDto);
            return CreatedAtAction(nameof(GetDayById), new {id = createdDay.DayId});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int dayId)
        {
            var result = await _dayservice.DeleteDayAsync(dayId);
            if (!result) return NotFound();
            return Ok("Day Has Been Deleted Successfully");
        }
    }

}

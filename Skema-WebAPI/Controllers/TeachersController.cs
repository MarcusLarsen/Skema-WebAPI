using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skema_WebAPI.Contexts;
using Skema_WebAPI.DTO;
using Skema_WebAPI.Interfaces;
using Skema_WebAPI.Models;

namespace Skema_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherDTO teacherDto)
        {
            if (teacherDto == null) return BadRequest();
            var createdTeacher = await _teacherService.AddTeacherAsync(teacherDto);
            return CreatedAtAction(nameof(GetTeacherById), new {id = createdTeacher.TeacherId});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            var result = await _teacherService.DeleteTeacherAsync(teacherId);
            if (!result) return NotFound();
            return Ok("Teacher Has Been Deleted Successfully");
        }
    }
}

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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
           var courses = await _courseService.GetAllCoursesAsync();
           return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseByIdAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseDTO courseDto)
        {
            if (courseDto == null) return BadRequest();
            var createdCourse = await _courseService.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourseById), new {id = createdCourse.CourseId});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            var result = await _courseService.DeleteCourseAsync(Id);
            if (!result) return NotFound();
            return Ok("Course Has Been Deleted Successfully");
        }
    }
}

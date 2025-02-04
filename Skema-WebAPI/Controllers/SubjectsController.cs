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

namespace Skema_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int subjectId)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(subjectId);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] SubjectDTO subjectDto)
        {
            if (subjectDto == null) return BadRequest();
            var createdSubject = await _subjectService.AddSubjectAsync(subjectDto);
            return CreatedAtAction(nameof(GetSubjectById), new { id = createdSubject.SubjectId });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            var result = await _subjectService.DeleteSubjectAsync(subjectId);
            if (!result) return NotFound();
            return Ok("Subject Has Been Deleted Successfully");
        }
    }
}

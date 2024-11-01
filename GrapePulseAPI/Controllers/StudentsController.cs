using GradePulseAPI.DTOs;
using GradePulseAPI.Services;
using GradePulseAPI.Services.Mapping;
using GrapePulseAPI.Data;
using GrapePulseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GrapePulseAPI.Controllers
{
    public class StudentsController : BaseController
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService) {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _studentService.GetAllStudentsAsync());     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _studentService.GetStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(await _studentService.GetStudentAsync(id));
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(await _studentService.AddStudentAsync(studentDto));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentToUpdate = await _studentService.GetStudentAsync(id);
            

            if (studentToUpdate == null)
                return NotFound();
            
            await _studentService.UpdateStudentAsync(id, dto);
            return Ok();           
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentToUpdate = await _studentService.GetStudentAsync(id);


            if (studentToUpdate == null)
                return NotFound();

            await _studentService.DeleteAsync(id);
            return Ok();
        }


    }
}

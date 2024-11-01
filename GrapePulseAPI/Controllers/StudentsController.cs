using GradePulseAPI.DTOs;
using GradePulseAPI.Services.Mapping;
using GrapePulseAPI.Data;
using GrapePulseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GrapePulseAPI.Controllers
{
    public class StudentsController : BaseController
    {
        private readonly SchoolDBContext _dbContext;
        private IEntityToDtoMapping _entityToDtoMapping;
        public StudentsController(SchoolDBContext context, IEntityToDtoMapping EntityToDtoMapping) {
            _dbContext = context;
            _entityToDtoMapping = EntityToDtoMapping;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _dbContext.Students.ToListAsync();

            var studentDtoList = _entityToDtoMapping.StudentEntityToDtoMApping(students);
            return studentDtoList;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if(student == null)
            {
                return  NotFound();
            }

           var studentDto =  _entityToDtoMapping.StudentEntityToDtoMApping(student);
           return studentDto;                       
        }
    }
}

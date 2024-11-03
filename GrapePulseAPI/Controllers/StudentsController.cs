using GradePulseAPI.DTOs;
using GradePulseAPI.Services;
using Microsoft.AspNetCore.Mvc;


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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(await _studentService.GetAllStudentsAsync());
            }
            catch (CustomErrorException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }

             
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            try
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
            catch (CustomErrorException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }

        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent(StudentDto studentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(await _studentService.AddStudentAsync(studentDto));
            }
            catch (CustomErrorException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }

            
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody] StudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var studentToUpdate = await _studentService.GetStudentAsync(id);


                if (studentToUpdate == null)
                    return NotFound();

                await _studentService.UpdateStudentAsync(id, dto);
                return Ok();
            }
            catch (CustomErrorException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
                  
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var studentToUpdate = await _studentService.GetStudentAsync(id);


                if (studentToUpdate == null)
                    return NotFound();

                await _studentService.DeleteAsync(id);
                return Ok();
            }
            catch (CustomErrorException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
           
        }


    }
}

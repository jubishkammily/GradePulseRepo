using GradePulseAPI.DTOs;
using GradePulseAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrapePulseAPI.Controllers
{
    public class SubjectsController : BaseController
    {
        private ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService) {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(await _subjectService.GetAllSubjectsAsync());
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
        public async Task<ActionResult<SubjectDto>> GetSubject(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var student = await _subjectService.GetSubjectAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
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

        [HttpPost("AddSubject")]
        public async Task<ActionResult> AddSubject(SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _subjectService.AddSubjectAsync(subjectDto));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] SubjectDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var studentToUpdate = await _subjectService.GetSubjectAsync(id);

                if (studentToUpdate == null)
                    return NotFound();

                await _subjectService.UpdateSubjectAsync(id, dto);
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

                var subjectToUpdate = await _subjectService.GetSubjectAsync(id);

                if (subjectToUpdate == null)
                    return NotFound();

                await _subjectService.DeleteAsync(id);
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

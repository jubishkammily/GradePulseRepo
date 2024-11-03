using GradePulseAPI.DTOs;
using GradePulseAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrapePulseAPI.Controllers
{
    public class GradesController : BaseController
    {
        private IGradeService _gradeService;
        public GradesController(IGradeService gradeService) {

            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetGrades()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(await _gradeService.GetAllGradesAsync());
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }
        }

        [HttpPost("AddGrade")]
        public async Task<ActionResult> AddGrade(GradeDto gradeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _gradeService.AddGradeAsync(gradeDto);
                return Ok(result);
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
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }            
            
        }

        [HttpGet("CrossTab")]
        public async Task<ActionResult> GetGradeCrossTab()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var crosstabData = await _gradeService.GetGradesCrosstabAsync();

                return Ok(crosstabData);
            }            
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

    }
           
        }



        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGrade([FromBody] GradeDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _gradeService.UpdateGradeAsync(dto);
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
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteGrade([FromBody] GradeDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                return BadRequest(ModelState);
          
            await _gradeService.DeleteAsync(dto.SubjectId,dto.StudentId);
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
            catch (Exception ex)
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

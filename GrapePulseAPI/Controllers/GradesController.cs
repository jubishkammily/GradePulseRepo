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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _gradeService.GetAllGradesAsync());
        }

        [HttpPost("AddGrade")]
        public async Task<ActionResult> AddGrade(GradeDto gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gradeService.AddGradeAsync(gradeDto);
            return Ok(result);
        }

        [HttpGet("CrossTab")]
        public async Task<ActionResult> GetGradeCrossTab()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var crosstabData = await _gradeService.GetGradesCrosstabAsync();

            return Ok(crosstabData);
        }
    }
}

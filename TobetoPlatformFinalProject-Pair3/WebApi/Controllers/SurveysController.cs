using Business.Abstracts;
using Business.Dtos.Survey.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        ISurveyService _surveyService;
        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateSurveyRequest createSurveyRequest)
        {
            var result = await _surveyService.AddAsync(createSurveyRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateSurveyRequest updateSurveyRequest)
        {
            var result = await _surveyService.UpdateAsync(updateSurveyRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteSurveyRequest deleteSurveyRequest)
        {
            var result = await _surveyService.DeleteAsync(deleteSurveyRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _surveyService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetSurveyRequest getSurveyRequest)
        {
            var result = await _surveyService.GetById(getSurveyRequest);
            return Ok(result);
        }
    }
}

using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        IEducationService _educationService;
        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateEducationRequest createEducationRequest)
        {
            var result = await _educationService.AddAsync(createEducationRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateEducationRequest updateEducationRequest)
        {
            var result = await _educationService.UpdateAsync(updateEducationRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteEducationRequest deleteEducationRequest)
        {
            var result = await _educationService.DeleteAsync(deleteEducationRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _educationService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetEducationRequest getEducationRequest)
        {
            var result = await _educationService.GetById(getEducationRequest);
            return Ok(result);
        }
    }
}


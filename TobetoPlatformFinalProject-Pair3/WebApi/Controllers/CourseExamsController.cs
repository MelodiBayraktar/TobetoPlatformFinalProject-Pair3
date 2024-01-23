using Business.Abstracts;
using Business.Dtos.CourseExam.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseExamsController : ControllerBase
    {
        ICourseExamService _courseExamService;
        public CourseExamsController(ICourseExamService courseExamService)
        {
            _courseExamService = courseExamService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseExamRequest createCourseExamRequest)
        {
            var result = await _courseExamService.AddAsync(createCourseExamRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseExamRequest updateCourseExamRequest)
        {
            var result = await _courseExamService.UpdateAsync(updateCourseExamRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCourseExamRequest deleteCourseExamRequest)
        {
            var result = await _courseExamService.DeleteAsync(deleteCourseExamRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseExamService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCourseExamRequest getCourseExamRequest)
        {
            var result = await _courseExamService.GetById(getCourseExamRequest);
            return Ok(result);
        }
    }
}

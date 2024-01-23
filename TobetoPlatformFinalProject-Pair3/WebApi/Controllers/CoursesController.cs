using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.AddAsync(createCourseRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.UpdateAsync(updateCourseRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCourseRequest deleteCourseRequest)
        {
            var result = await _courseService.DeleteAsync(deleteCourseRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCourseRequest getCourseRequest)
        {
            var result = await _courseService.GetById(getCourseRequest);
            return Ok(result);
        }
    }
}

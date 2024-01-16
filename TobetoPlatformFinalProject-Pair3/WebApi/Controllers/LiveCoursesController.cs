using Business.Abstracts;
using Business.Dtos.LiveCourse.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveCoursesController : ControllerBase
    {
        ILiveCourseService _liveCourseService;
        public LiveCoursesController(ILiveCourseService liveCourseService)
        {
            _liveCourseService = liveCourseService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateLiveCourseRequest createLiveCourseRequest)
        {
            var result = await _liveCourseService.AddAsync(createLiveCourseRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateLiveCourseRequest updateLiveCourseRequest)
        {
            var result = await _liveCourseService.UpdateAsync(updateLiveCourseRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteLiveCourseRequest deleteLiveCourseRequest)
        {
            var result = await _liveCourseService.DeleteAsync(deleteLiveCourseRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _liveCourseService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetLiveCourseRequest getLiveCourseRequest)
        {
            var result = await _liveCourseService.GetById(getLiveCourseRequest);
            return Ok(result);
        }
    }
}

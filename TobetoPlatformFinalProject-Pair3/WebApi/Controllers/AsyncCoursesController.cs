using Business.Abstracts;
using Business.Dtos.AsyncCourse.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsyncCoursesController : ControllerBase
{
    IAsyncCourseService _asyncCourseService;
    public AsyncCoursesController(IAsyncCourseService asyncCourseService)
    {
        _asyncCourseService = asyncCourseService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAsyncCourseRequest createAsyncCourseRequest)
    {
        var result = await _asyncCourseService.AddAsync(createAsyncCourseRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAsyncCourseRequest updateAsyncCourseRequest)
    {
        var result = await _asyncCourseService.UpdateAsync(updateAsyncCourseRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAsyncCourseRequest deleteAsyncCourseRequest)
    {
        var result = await _asyncCourseService.DeleteAsync(deleteAsyncCourseRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _asyncCourseService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAsyncCourseRequest getAsyncCourseRequest)
    {
        var result = await _asyncCourseService.GetById(getAsyncCourseRequest);
        return Ok(result);
    }
}

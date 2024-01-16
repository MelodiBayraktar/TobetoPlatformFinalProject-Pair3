using Business.Abstracts;
using Business.Dtos.AsyncLessonsOfContent.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsyncLessonsOfContentsController : ControllerBase
{
    IAsyncLessonsOfContentService _asyncLessonsOfContentService;
    public AsyncLessonsOfContentsController(IAsyncLessonsOfContentService asyncLessonsOfContentService)
    {
        _asyncLessonsOfContentService = asyncLessonsOfContentService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAsyncLessonsOfContentRequest createAsyncLessonsOfContentRequest)
    {
        var result = await _asyncLessonsOfContentService.AddAsync(createAsyncLessonsOfContentRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAsyncLessonsOfContentRequest updateAsyncLessonsOfContentRequest)
    {
        var result = await _asyncLessonsOfContentService.UpdateAsync(updateAsyncLessonsOfContentRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAsyncLessonsOfContentRequest deleteAsyncLessonsOfContentRequest)
    {
        var result = await _asyncLessonsOfContentService.DeleteAsync(deleteAsyncLessonsOfContentRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _asyncLessonsOfContentService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAsyncLessonsOfContentRequest getAsyncLessonsOfContentRequest)
    {
        var result = await _asyncLessonsOfContentService.GetById(getAsyncLessonsOfContentRequest);
        return Ok(result);
    }
}

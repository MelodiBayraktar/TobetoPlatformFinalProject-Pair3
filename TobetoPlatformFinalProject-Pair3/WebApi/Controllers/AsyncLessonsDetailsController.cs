using Business.Abstracts;
using Business.Dtos.AsyncLessonsDetail.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsyncLessonsDetailsController : ControllerBase
{
    IAsyncLessonsDetailService _asyncLessonsDetailService;
    public AsyncLessonsDetailsController(IAsyncLessonsDetailService asyncLessonsDetailService)
    {
        _asyncLessonsDetailService = asyncLessonsDetailService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAsyncLessonsDetailRequest createAsyncLessonsDetailRequest)
    {
        var result = await _asyncLessonsDetailService.AddAsync(createAsyncLessonsDetailRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAsyncLessonsDetailRequest updateAsyncLessonsDetailRequest)
    {
        var result = await _asyncLessonsDetailService.UpdateAsync(updateAsyncLessonsDetailRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAsyncLessonsDetailRequest deleteAsyncLessonsDetailRequest)
    {
        var result = await _asyncLessonsDetailService.DeleteAsync(deleteAsyncLessonsDetailRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _asyncLessonsDetailService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAsyncLessonsDetailRequest getAsyncLessonsDetailRequest)
    {
        var result = await _asyncLessonsDetailService.GetById(getAsyncLessonsDetailRequest);
        return Ok(result);
    }
}

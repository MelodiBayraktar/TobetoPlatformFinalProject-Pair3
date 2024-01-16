using Business.Abstracts;
using Business.Dtos.AsyncContent.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsyncContentsController : ControllerBase
{
    IAsyncContentService _asyncContentService;
    public AsyncContentsController(IAsyncContentService asyncContentService)
    {
        _asyncContentService = asyncContentService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAsyncContentRequest createAsyncContentRequest)
    {
        var result = await _asyncContentService.AddAsync(createAsyncContentRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAsyncContentRequest updateAsyncContentRequest)
    {
        var result = await _asyncContentService.UpdateAsync(updateAsyncContentRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAsyncContentRequest deleteAsyncContentRequest)
    {
        var result = await _asyncContentService.DeleteAsync(deleteAsyncContentRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _asyncContentService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAsyncContentRequest getAsyncContentRequest)
    {
        var result = await _asyncContentService.GetById(getAsyncContentRequest);
        return Ok(result);
    }
}

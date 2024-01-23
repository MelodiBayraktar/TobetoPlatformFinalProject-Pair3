using Business.Abstracts;
using Business.Dtos.Application.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    IApplicationService _applicationService;
    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateApplicationRequest createApplicationRequest)
    {
        var result = await _applicationService.AddAsync(createApplicationRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateApplicationRequest updateApplicationRequest)
    {
        var result = await _applicationService.UpdateAsync(updateApplicationRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteApplicationRequest deleteApplicationRequest)
    {
        var result = await _applicationService.DeleteAsync(deleteApplicationRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _applicationService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetApplicationRequest getApplicationRequest)
    {
        var result = await _applicationService.GetById(getApplicationRequest);
        return Ok(result);
    }
}

using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    IAnnouncementService _announcementService;
    public AnnouncementsController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAnnouncementRequest createAnnouncementRequest)
    {
        var result = await _announcementService.AddAsync(createAnnouncementRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAnnouncementRequest updateAnnouncementRequest)
    {
        var result = await _announcementService.UpdateAsync(updateAnnouncementRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAnnouncementRequest deleteAnnouncementRequest)
    {
        var result = await _announcementService.DeleteAsync(deleteAnnouncementRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
    {
        var result = await _announcementService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAnnouncementRequest getAnnouncementRequest)
    {
        var result = await _announcementService.GetById(getAnnouncementRequest);
        return Ok(result);
    }
}

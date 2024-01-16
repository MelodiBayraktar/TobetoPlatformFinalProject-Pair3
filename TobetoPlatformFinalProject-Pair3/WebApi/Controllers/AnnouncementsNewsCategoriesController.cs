using Business.Abstracts;
using Business.Dtos.AnnouncementsNewsCategory.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsNewsCategoriesController : ControllerBase
{
    IAnnouncementsNewsCategoryService _announcementsNewsCategoryService;
    public AnnouncementsNewsCategoriesController(IAnnouncementsNewsCategoryService announcementsNewsCategoryService)
    {
        _announcementsNewsCategoryService = announcementsNewsCategoryService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAnnouncementsNewsCategoryRequest createAnnouncementsNewsCategoryRequest)
    {
        var result = await _announcementsNewsCategoryService.AddAsync(createAnnouncementsNewsCategoryRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAnnouncementsNewsCategoryRequest updateAnnouncementsNewsCategoryRequest)
    {
        var result = await _announcementsNewsCategoryService.UpdateAsync(updateAnnouncementsNewsCategoryRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAnnouncementsNewsCategoryRequest deleteAnnouncementsNewsCategoryRequest)
    {
        var result = await _announcementsNewsCategoryService.DeleteAsync(deleteAnnouncementsNewsCategoryRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery]PageRequest pageRequest)
    {
        var result = await _announcementsNewsCategoryService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAnnouncementsNewsCategoryRequest getAnnouncementsNewsCategoryRequest)
    {
        var result = await _announcementsNewsCategoryService.GetById(getAnnouncementsNewsCategoryRequest);
        return Ok(result);
    }
}

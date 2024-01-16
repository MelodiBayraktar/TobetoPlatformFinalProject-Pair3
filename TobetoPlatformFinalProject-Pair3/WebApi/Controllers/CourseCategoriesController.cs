using Business.Abstracts;
using Business.Dtos.CourseCategory.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseCategoriesController : ControllerBase
{
    ICourseCategoryService _courseCategoryService;
    public CourseCategoriesController(ICourseCategoryService courseCategoryService)
    {
        _courseCategoryService = courseCategoryService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateCourseCategoryRequest createCourseCategoryRequest)
    {
        var result = await _courseCategoryService.AddAsync(createCourseCategoryRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateCourseCategoryRequest updateCourseCategoryRequest)
    {
        var result = await _courseCategoryService.UpdateAsync(updateCourseCategoryRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteCourseCategoryRequest deleteCourseCategoryRequest)
    {
        var result = await _courseCategoryService.DeleteAsync(deleteCourseCategoryRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _courseCategoryService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetCourseCategoryRequest getCourseCategoryRequest)
    {
        var result = await _courseCategoryService.GetById(getCourseCategoryRequest);
        return Ok(result);
    }
}

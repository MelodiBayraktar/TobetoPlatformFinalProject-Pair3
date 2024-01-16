using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.CourseDetail.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        ICourseDetailService _courseDetailService;
        public CourseDetailsController(ICourseDetailService courseDetailService)
        {
            _courseDetailService = courseDetailService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateCourseDetailRequest createCourseDetailRequest)
        {
            var result = await _courseDetailService.AddAsync(createCourseDetailRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateCourseDetailRequest updateCourseDetailRequest)
        {
            var result = await _courseDetailService.UpdateAsync(updateCourseDetailRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteCourseDetailRequest deleteCourseDetailRequest)
        {
            var result = await _courseDetailService.DeleteAsync(deleteCourseDetailRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseDetailService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCourseDetailRequest getCourseDetailRequest)
        {
            var result = await _courseDetailService.GetById(getCourseDetailRequest);
            return Ok(result);
        }
    }
}

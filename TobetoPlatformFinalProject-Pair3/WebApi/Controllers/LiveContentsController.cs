using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.LiveContent.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveContentsController : ControllerBase
    {
        ILiveContentService _liveContentService;
        public LiveContentsController(ILiveContentService liveContentService)
        {
            _liveContentService = liveContentService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateLiveContentRequest createLiveContentRequest)
        {
            var result = await _liveContentService.AddAsync(createLiveContentRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateLiveContentRequest updateLiveContentRequest)
        {
            var result = await _liveContentService.UpdateAsync(updateLiveContentRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteLiveContentRequest deleteLiveContentRequest)
        {
            var result = await _liveContentService.DeleteAsync(deleteLiveContentRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _liveContentService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetLiveContentRequest getLiveContentRequest)
        {
            var result = await _liveContentService.GetById(getLiveContentRequest);
            return Ok(result);
        }
    }
}

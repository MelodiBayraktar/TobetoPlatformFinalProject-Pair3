using Business.Abstracts;
using Business.Dtos.News.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateNewsRequest createNewsRequest)
        {
            var result = await _newsService.AddAsync(createNewsRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateNewsRequest updateNewsRequest)
        {
            var result = await _newsService.UpdateAsync(updateNewsRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteNewsRequest deleteNewsRequest)
        {
            var result = await _newsService.DeleteAsync(deleteNewsRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _newsService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetNewsRequest getNewsRequest)
        {
            var result = await _newsService.GetById(getNewsRequest);
            return Ok(result);
        }
    }
}

using Business.Abstracts;
using Business.Dtos.Session.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        ISessionService _sessionService;
        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateSessionRequest createSessionRequest)
        {
            var result = await _sessionService.AddAsync(createSessionRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSessionRequest updateSessionRequest)
        {
            var result = await _sessionService.UpdateAsync(updateSessionRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSessionRequest deleteSessionRequest)
        {
            var result = await _sessionService.DeleteAsync(deleteSessionRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _sessionService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetSessionRequest getSessionRequest)
        {
            var result = await _sessionService.GetById(getSessionRequest);
            return Ok(result);
        }
    }
}

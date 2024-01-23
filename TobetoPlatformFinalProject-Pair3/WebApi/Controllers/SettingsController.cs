using Business.Abstracts;
using Business.Dtos.Settings.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSettingsRequest updateSettingsRequest)
        {
            var result = await _settingsService.UpdateAsync(updateSettingsRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSettingsRequest deleteSettingsRequest)
        {
            var result = await _settingsService.DeleteAsync(deleteSettingsRequest); return Ok(result);
        }

    }
}

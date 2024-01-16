using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Settings.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateSettingsRequest updateSettingsRequest)
        {
            var result = await _settingsService.UpdateAsync(updateSettingsRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteSettingsRequest deleteSettingsRequest)
        {
            var result = await _settingsService.DeleteAsync(deleteSettingsRequest); return Ok(result);
        }

    }
}

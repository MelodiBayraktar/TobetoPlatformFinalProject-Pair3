using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.PasswordReset.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetsController : ControllerBase
    {
        IPasswordResetService _passwordResetService;
        public PasswordResetsController(IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdatePasswordResetRequest updatePasswordResetRequest)
        {
            var result = await _passwordResetService.UpdateAsync(updatePasswordResetRequest); return Ok(result);
        }
    }
}

using Business.Abstracts;
using Business.Dtos.User.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _userService.AddAsync(createUserRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.UpdateAsync(updateUserRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserRequest deleteUserRequest)
        {
            var result = await _userService.DeleteAsync(deleteUserRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _userService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetUserRequest getUserRequest)
        {
            var result = await _userService.GetById(getUserRequest);
            return Ok(result);
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordRequest updateUserPasswordRequest)
        {
            var result = await _userService.UpdatePassword(updateUserPasswordRequest); 
            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] PasswordResetEmailRequest passwordResetEmailRequest)
        {
            var result = await _userService.ForgotPassword(passwordResetEmailRequest);
            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            var result = await _userService.ResetPassword(resetPasswordRequest);
            return Ok(result);
        }

        //[HttpPost("ResetPassword")]
        //public async Task<IActionResult> ResetPassword([FromQuery] string token, [FromBody] ResetPasswordRequest resetPasswordRequest)
        //{
        //    var result = await _userService.ResetPassword(token, resetPasswordRequest);
        //    return Ok(result);
        //}
    }
}

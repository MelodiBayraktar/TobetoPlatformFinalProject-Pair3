using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.SocialAccount.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialAccountsController : ControllerBase
    {
        ISocialAccountService _socialAccountService;
        public SocialAccountsController(ISocialAccountService socialAccountService)
        {
            _socialAccountService = socialAccountService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateSocialAccountRequest createSocialAccountRequest)
        {
            var result = await _socialAccountService.AddAsync(createSocialAccountRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateSocialAccountRequest updateSocialAccountRequest)
        {
            var result = await _socialAccountService.UpdateAsync(updateSocialAccountRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteSocialAccountRequest deleteSocialAccountRequest)
        {
            var result = await _socialAccountService.DeleteAsync(deleteSocialAccountRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _socialAccountService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetSocialAccountRequest getSocialAccountRequest)
        {
            var result = await _socialAccountService.GetById(getSocialAccountRequest);
            return Ok(result);
        }
    }
}

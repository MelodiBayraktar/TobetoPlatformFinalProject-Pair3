﻿using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimRequest userOperationClaimRequest)
        {
            var result = await _userOperationClaimService.AddAsync(userOperationClaimRequest);
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetUserOperationClaimRequest getUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.GetById(getUserOperationClaimRequest);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _userOperationClaimService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.DeleteAsync(deleteUserOperationClaimRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.UpdateAsync(updateUserOperationClaimRequest); return Ok(result);
        }
    }
}

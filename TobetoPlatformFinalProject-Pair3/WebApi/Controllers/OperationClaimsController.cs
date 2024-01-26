﻿using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.Student.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimRequest operationClaimRequest)
        {
            var result = await _operationClaimService.AddAsync(operationClaimRequest);
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetOperationClaimRequest getOperationClaimRequest)
        {
            var result = await _operationClaimService.GetById(getOperationClaimRequest);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _operationClaimService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimRequest deleteOperationClaimRequest)
        {
            var result = await _operationClaimService.DeleteAsync(deleteOperationClaimRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            var result = await _operationClaimService.UpdateAsync(updateOperationClaimRequest); return Ok(result);
        }
    }
}

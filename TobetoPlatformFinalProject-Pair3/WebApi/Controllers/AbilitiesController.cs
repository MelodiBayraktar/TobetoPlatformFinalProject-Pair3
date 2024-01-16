using Business.Abstracts;
using Business.Dtos.Ability.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilitiesController : ControllerBase
{
    IAbilityService _abilityService;
    public AbilitiesController(IAbilityService abilityService)
    {
        _abilityService = abilityService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromQuery] CreateAbilityRequest createAbilityRequest)
    {
        var result = await _abilityService.AddAsync(createAbilityRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromQuery] UpdateAbilityRequest updateAbilityRequest)
    {
        var result = await _abilityService.UpdateAsync(updateAbilityRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteAbilityRequest deleteAbilityRequest)
    {
        var result = await _abilityService.DeleteAsync(deleteAbilityRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _abilityService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetAbilityRequest getAbilityRequest)
    {
        var result = await _abilityService.GetById(getAbilityRequest);
        return Ok(result);
    }
}

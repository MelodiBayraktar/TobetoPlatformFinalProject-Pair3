using Business.Abstracts;
using Business.Dtos.PersonalInfo.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfosController : ControllerBase
    {
        IPersonalInfoService _personalInfoService;
        public PersonalInfosController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreatePersonalInfoRequest createPersonalInfoRequest)
        {
            var result = await _personalInfoService.AddAsync(createPersonalInfoRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdatePersonalInfoRequest updatePersonalInfoRequest)
        {
            var result = await _personalInfoService.UpdateAsync(updatePersonalInfoRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeletePersonalInfoRequest deletePersonalInfoRequest)
        {
            var result = await _personalInfoService.DeleteAsync(deletePersonalInfoRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _personalInfoService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetPersonalInfoRequest getPersonalInfoRequest)
        {
            var result = await _personalInfoService.GetById(getPersonalInfoRequest);
            return Ok(result);
        }
    }
}

using Business.Abstracts;
using Business.Dtos.ForeignLanguage.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguagesController : ControllerBase
    {
        IForeignLanguageService _foreignLanguageService;
        public ForeignLanguagesController(IForeignLanguageService foreignLanguageService)
        {
            _foreignLanguageService = foreignLanguageService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateForeignLanguageRequest createForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.AddAsync(createForeignLanguageRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateForeignLanguageRequest updateForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.UpdateAsync(updateForeignLanguageRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteForeignLanguageRequest deleteForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.DeleteAsync(deleteForeignLanguageRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _foreignLanguageService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetForeignLanguageRequest getForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.GetById(getForeignLanguageRequest);
            return Ok(result);
        }
    }
}

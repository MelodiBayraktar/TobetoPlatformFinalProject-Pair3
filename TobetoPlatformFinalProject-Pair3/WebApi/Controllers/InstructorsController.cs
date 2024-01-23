using Business.Abstracts;
using Business.Dtos.Instructor.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.AddAsync(createInstructorRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.UpdateAsync(updateInstructorRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteInstructorRequest deleteInstructorRequest)
        {
            var result = await _instructorService.DeleteAsync(deleteInstructorRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _instructorService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetInstructorRequest getInstructorRequest)
        {
            var result = await _instructorService.GetById(getInstructorRequest);
            return Ok(result);
        }
    }
}

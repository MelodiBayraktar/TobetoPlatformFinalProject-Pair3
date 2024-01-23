using Business.Abstracts;
using Business.Dtos.Student.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateStudentRequest createStudentRequest)
        {
            var result = await _studentService.AddAsync(createStudentRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStudentRequest updateStudentRequest)
        {
            var result = await _studentService.UpdateAsync(updateStudentRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteStudentRequest deleteStudentRequest)
        {
            var result = await _studentService.DeleteAsync(deleteStudentRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetStudentRequest getStudentRequest)
        {
            var result = await _studentService.GetById(getStudentRequest);
            return Ok(result);
        }
    }
}

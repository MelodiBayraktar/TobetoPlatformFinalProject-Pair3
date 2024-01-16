using Business.Abstracts;
using Business.Dtos.ContactUs.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromQuery] CreateContactUsRequest createContactUsRequest)
        {
            var result = await _contactUsService.AddAsync(createContactUsRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateContactUsRequest updateContactUsRequest)
        {
            var result = await _contactUsService.UpdateAsync(updateContactUsRequest); return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteContactUsRequest deleteContactUsRequest)
        {
            var result = await _contactUsService.DeleteAsync(deleteContactUsRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _contactUsService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetContactUsRequest getContactUsRequest)
        {
            var result = await _contactUsService.GetById(getContactUsRequest);
            return Ok(result);
        }
    }

}

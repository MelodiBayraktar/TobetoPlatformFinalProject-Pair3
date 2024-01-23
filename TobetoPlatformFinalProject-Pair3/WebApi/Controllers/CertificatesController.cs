using Business.Abstracts;
using Business.Dtos.Certificate.Requests;
using Core.Utilities.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : ControllerBase
{
    ICertificateService _certificateService;
    public CertificatesController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCertificateRequest createCertificateRequest)
    {
        var result = await _certificateService.AddAsync(createCertificateRequest); return Ok(result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCertificateRequest updateCertificateRequest)
    {
        var result = await _certificateService.UpdateAsync(updateCertificateRequest); return Ok(result);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCertificateRequest deleteCertificateRequest)
    {
        var result = await _certificateService.DeleteAsync(deleteCertificateRequest); return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _certificateService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetCertificateRequest getCertificateRequest)
    {
        var result = await _certificateService.GetById(getCertificateRequest);
        return Ok(result);
    }
}

using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Auth.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;
    private IMapper _mapper;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromQuery] AuthForLoginRequest authForLoginRequest)
    {


        var userToLogin = await _authService.Login(authForLoginRequest);


        var result = _authService.CreateAccessToken(userToLogin);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromQuery] AuthForRegisterRequest authForRegisterRequest)
    {
        await _authService.UserExists(authForRegisterRequest.Email);


        var registerResult = await _authService.Register(authForRegisterRequest, authForRegisterRequest.Password);

        var result = _authService.CreateAccessToken(registerResult);
        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest(result);
        //return Ok(registerResult);
    }
}

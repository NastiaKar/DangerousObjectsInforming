using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Route("auth/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost, Route("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        return Ok(await _service.RegisterAsync(request));
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        return Ok(await _service.LoginAsync(request));
    }
}
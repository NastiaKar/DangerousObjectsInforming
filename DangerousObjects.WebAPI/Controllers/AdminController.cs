using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.Constants;
using DangerousObjectsCommon.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Route("admin/")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AdminController : ControllerBase
{
    private readonly IAdminService _service;
    private readonly IUserService _userService;
    
    public AdminController(IAdminService service, IUserService userService)
    {
        _service = service;
        _userService = userService;
    }

    [HttpPut, Route("user/verify/{userId}")]
    public async Task<IActionResult> VerifyUser(int userId)
    {
        await _service.VerifyUser(userId);
        return Ok();
    }
    
    [HttpGet, Route("user/list")]
    public async Task<IActionResult> GetUnverified()
    {
        var users = await _service.GetUnverified();
        return Ok(users);
    }
}
using DangerousObjectsBLL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("admin/")]
[ApiController]
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
        var users = await _userService.GetUnverified();
        return Ok(users);
    }
}
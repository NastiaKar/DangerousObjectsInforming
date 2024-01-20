using DangerousObjectsBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _service;
    
    public AdminController(IAdminService service)
    {
        _service = service;
    }

    [HttpPut("VerifyUser/{userId}")]
    public async Task<IActionResult> VerifyUser(int userId)
    {
        await _service.VerifyUser(userId);
        return Ok();
    }
}
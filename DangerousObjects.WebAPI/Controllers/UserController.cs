using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAll();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetById(id);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateUser request, int id)
    {
        try
        {
            var user = await _service.Update(id, request);
            return Ok(user);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
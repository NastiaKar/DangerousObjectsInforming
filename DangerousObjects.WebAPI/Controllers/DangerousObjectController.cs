using System.Security.Claims;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.DangerousObject;
using DangerousObjectsInforming.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class DangerousObjectController : ControllerBase
{
    private readonly IDangerousObjectService _service;
    private readonly IHttpContextAccessor _accessor;
    
    public DangerousObjectController(IDangerousObjectService service, IHttpContextAccessor accessor)
    {
        _service = service;
        _accessor = accessor;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dangerousObjects = await _service.GetAll();
        return Ok(dangerousObjects);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dangerousObject = await _service.GetById(id);
        return Ok(dangerousObject);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateDangerousObject request)
    {

        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var displayDangerousObject = await _service.Create(request, userId);
        return CreatedAtAction(nameof(GetById), new { id = displayDangerousObject.Id }, displayDangerousObject);
        
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateDangerousObject request, int id)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var displayDangerousObject = await _service.Update(id, request, userId);
            return Ok(displayDangerousObject);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _service.Delete(id, userId);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
using System.Security.Claims;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.Message;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DangerousObjectsInforming.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("message/")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;
    
    public MessageController(IMessageService service)
    {
        _service = service;
    }
    
    [HttpGet, Route("list")]
    public async Task<IActionResult> GetAll()
    {
        var messages = await _service.GetAll();
        return Ok(messages);
    }
    
    [HttpGet, Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var message = await _service.GetById(id);
        return Ok(message);
    }
    
    [HttpPost, Route("create")]
    public async Task<IActionResult> Create([FromBody]CreateMessage request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var displayMessage = await _service.Create(request, userId);
            return CreatedAtAction(nameof(GetById), new { id = displayMessage.Id }, displayMessage);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpPut, Route("update/{id}")]
    public async Task<IActionResult> Update([FromBody]UpdateMessage request, int id)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var displayMessage = await _service.Update(id, request, userId);
            return Ok(displayMessage);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete, Route("delete/{id}")]
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
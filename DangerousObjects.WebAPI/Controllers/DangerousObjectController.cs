using System.Net;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.DangerousObject;
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

    public DangerousObjectController(IDangerousObjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateDangerousObject request, int userId)
    {
        throw new NotImplementedException();
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DangerousObjects.MVC.Models;
using DangerousObjects.MVC.Services.Interfaces;

namespace DangerousObjects.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService _service;

    public HomeController(IAuthService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        UserLoginModel userLoginModel = new UserLoginModel();
        return View(userLoginModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel userLoginModel)
    {
        if (ModelState.IsValid)
        {
            var authResult = await _service.GetUserByLogin(userLoginModel);
            if (authResult.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", authResult.Response);
            }
        }
        return View(userLoginModel);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
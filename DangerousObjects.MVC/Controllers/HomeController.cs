using System.Diagnostics;
using System.Text.Json;
using DangerousObjects.MVC.Helpers.Constants;
using DangerousObjects.MVC.Helpers.Enums;
using DangerousObjects.MVC.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using DangerousObjects.MVC.Models;
using DangerousObjects.MVC.Services.Interfaces;

namespace DangerousObjects.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService _service;
    private readonly IUserService _userService;

    public HomeController(IAuthService service, IUserService userService)
    {
        _service = service;
        _userService = userService;
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
        try
        {
            if (ModelState.IsValid)
            {
                var authResult = await _service.GetUserByLogin(userLoginModel);
                
                if (authResult.IsSuccess)
                {
                    return RedirectToAction("Index", new { token = authResult.Response });
                }
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(userLoginModel);
    }

    [HttpGet]
    public IActionResult Verify(FullUserModel userModel)
    {
        return View(userModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Verify(int id, string token)
    {
        try
        {
            var result = await _userService.VerifyUser(id, token);

            if (result)
            {
                return RedirectToAction("Index", new { token = token });
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return RedirectToAction("Index", new { token = token });
    }

    [HttpGet]
    public async Task<IActionResult> Main(string token)
    {
        var result = await _userService.GetUserProfile(token);

        if (result == null)
        {
            return RedirectToAction("Login");
        }

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddDangerousObject(string token, int userId)
    {
        var dangerObj = new DangerousObjectModel()
        {
            Token = token,
            OwnerId = userId
        };

        return View(dangerObj);
    }

    [HttpPost]
    public async Task<IActionResult> AddDangerousObject(DangerousObjectModel model)
    {
        try
        {
            var result = await _userService.AddDangerousObject(model);

            if (result)
            {
                return RedirectToAction("Main", new { token = model.Token });
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return RedirectToAction("AddDangerousObject", new { token = model.Token, userId = model.OwnerId });
    }

    [HttpGet]
    public async Task<IActionResult> GetDangerousObjects(string token)
    {
        var result = await _userService.GetDangerousObjects(token);

        if (result == null)
        {
            return RedirectToAction("Login");
        }

        return View(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMessages(string token)
    {
        var result = await _userService.GetMessages(token);

        if (result == null)
        {
            return RedirectToAction("Login");
        }

        return View(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddMessage(string token, int userId)
    {
        var message = new MessageModel()
        {
            Token = token,
            OwnerId = userId
        };

        return View(message);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMessage(MessageModel model)
    {
        try
        {
            var result = await _userService.AddMessage(model);

            if (result)
            {
                return RedirectToAction("Main", new { token = model.Token });
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return RedirectToAction("AddMessage", new { token = model.Token, userId = model.OwnerId });
    }

    [HttpGet]
    public IActionResult Register()
    {
        var userRegisterModel = new UserRegisterModel();
        return View(userRegisterModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _service.RegisterUser(userRegisterModel);

                if (result == true)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    userRegisterModel.ErrorMessage = ErrorMessages.EmailIsTaken;
                    return View(userRegisterModel);
                }
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View(userRegisterModel);
    }

    [HttpGet]
    public async Task<IActionResult> Index(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login");
        }

        if (token.IsJson())
        {
            var jsonDoc = JsonDocument.Parse(token);
            var root = jsonDoc.RootElement;
            string? tokenStr = root.GetProperty("token").GetString();
            token = tokenStr!;
        }

        return RedirectToAction("Main", new { token = token });
        
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
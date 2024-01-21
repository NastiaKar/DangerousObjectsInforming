using DangerousObjects.MVC.Helpers.DTOs;
using DangerousObjects.MVC.Models;

namespace DangerousObjects.MVC.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResultDto> GetUserByLogin(UserLoginModel request);
}
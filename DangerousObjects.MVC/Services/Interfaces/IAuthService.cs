using DangerousObjects.MVC.Models;
using DangerousObjectsCommon.Auth;

namespace DangerousObjects.MVC.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> GetUserByLogin(UserLoginModel request);
}
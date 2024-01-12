using DangerousObjectsCommon.Auth;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(UserRegisterRequest request);
    Task<AuthResult> LoginAsync(UserLoginRequest request);
}
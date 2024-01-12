using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DangerousObjectsBLL.Configure;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.Auth;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DangerousObjectsBLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepo _userRepo;
    private readonly IPasswordHasher _passwordHasher;
    private readonly JwtConfig _jwtConfig;

    public AuthService(IUserRepo userRepo, IPasswordHasher passwordHasher, IOptionsMonitor<JwtConfig> optionsMonitor)
    {
        _userRepo = userRepo;
        _passwordHasher = passwordHasher;
        _jwtConfig = optionsMonitor.CurrentValue;
    }

    public async Task<AuthResult> RegisterAsync(UserRegisterRequest request)
    {
        var user = await _userRepo.FindByEmailAsync(request.Email);
        if (user != null)
            return new AuthResult {Success = false, Errors = new []{ "Email already registered." }};

        string salt = _passwordHasher.GenerateSalt();
        string passwordHash = _passwordHasher.HashPassword(request.Password, salt);
        var newUser = new User { Email = request.Email, Salt = salt, PasswordHash = passwordHash };

        bool created = await _userRepo.AddAsync(newUser) > 0;
        if (!created)
            return new AuthResult { Success = false, Errors = new[] { "Could not register a user." } };

        return new AuthResult { Success = true, Token = GenerateJwtToken(newUser)};
    }

    public async Task<AuthResult> LoginAsync(UserLoginRequest request)
    {
        var user = await _userRepo.FindByEmailAsync(request.Email);
        if (user == null)
            return new AuthResult { Success = false, Errors = new[] { "User with this email does not exist." } };

        bool correctPassword = user.PasswordHash == 
                               _passwordHasher.HashPassword(request.Password, user.Salt);
        if (!correctPassword)
            return new AuthResult { Success = false, Errors = new[] { "Password is incorrect" } };

        return new AuthResult { Success = true, Token = GenerateJwtToken(user) };
    }

    private string GenerateJwtToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(new[] {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        string jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
}
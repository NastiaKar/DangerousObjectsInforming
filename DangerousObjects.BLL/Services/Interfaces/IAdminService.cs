namespace DangerousObjectsBLL.Services.Interfaces;

public interface IAdminService
{
    Task VerifyUser(int userId);
}
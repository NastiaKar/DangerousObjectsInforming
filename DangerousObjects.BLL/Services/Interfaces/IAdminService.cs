using DangerousObjectsCommon.DTOs.User;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IAdminService
{
    Task VerifyUser(int userId);

    Task<IEnumerable<DisplayUser>> GetUnverified();
}
using DangerousObjectsCommon.DTOs.User;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<DisplayUser>> GetAll();
    Task<DisplayUser> GetById(int id);
    Task<DisplayUser> Update(int id, UpdateUser user);
    Task Delete(int id);
    Task<IEnumerable<DisplayUser>> GetUnverified();
}
using DangerousObjectsDAL.Entities;

namespace DangerousObjectsDAL.Repositories.Interfaces;

public interface IUserRepo : IRepo<User>
{
    Task<User?> FindByEmailAsync(string email);
    Task<User?> FindByIdAsync(int id);
}
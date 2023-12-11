using DangerousObjectsDAL.Entities;

namespace DangerousObjectsDAL.Repositories.Interfaces;

public interface IUserRepo : IRepo<User>
{
    Task<User?> FindByEmailAsync(string email);
}
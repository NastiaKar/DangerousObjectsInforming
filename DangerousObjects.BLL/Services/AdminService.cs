using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.Exceptions;
using DangerousObjectsDAL.Repositories.Interfaces;

namespace DangerousObjectsBLL.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepo _repo;

    public AdminService(IUserRepo repo)
    {
        _repo = repo;
    }
    
    public async Task VerifyUser(int userId)
    {
        var user = await _repo.FindByIdAsync(userId);
        
        if (user == null)
            throw new UserNotFoundException(nameof(user), "User not found.");
        if (user.IsVerified)
            throw new UserAlreadyVerifiedException(nameof(user), "User is already verified.");
        
        user.IsVerified = true;
        await _repo.UpdateAsync(user);
    }
}
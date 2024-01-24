using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.User;
using DangerousObjectsCommon.Exceptions;
using DangerousObjectsDAL.Repositories.Interfaces;
using AutoMapper;

namespace DangerousObjectsBLL.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepo _repo;
    private readonly IMapper _mapper;

    public AdminService(IUserRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
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
    
    public async Task<IEnumerable<DisplayUser>> GetUnverified()
    {
        var users = await _repo.GetAllAsync();
        var unverified = users.Where(u => !u.IsVerified);
        return _mapper.Map<IEnumerable<DisplayUser>>(unverified);
    }
}
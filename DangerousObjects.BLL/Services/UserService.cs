using AutoMapper;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.User;
using DangerousObjectsCommon.Exceptions;
using DangerousObjectsDAL.Repositories.Interfaces;

namespace DangerousObjectsBLL.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _repo;

    public UserService(IMapper mapper, IUserRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task<IEnumerable<DisplayUser>> GetAll()
    {
        var users = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DisplayUser>>(users);
    }

    public async Task<DisplayUser> GetById(int id)
    {
        var user = await _repo.FindAsync(id);
        if (user == null)
            throw new UserNotFoundException(nameof(user),"User not found.");
        return _mapper.Map<DisplayUser>(user);
    }

    public async Task<DisplayUser> Update(int id, UpdateUser user)
    {
        var userEntity = await _repo.FindAsync(id);
        if (userEntity == null)
            throw new UserNotFoundException(nameof(user),"User not found.");
        userEntity = _mapper.Map(user, userEntity);
        await _repo.UpdateAsync(userEntity);
        return _mapper.Map<DisplayUser>(userEntity);
    }

    public async Task Delete(int id)
    {
        var user = await _repo.FindAsync(id);
        if (user == null)
            throw new UserNotFoundException(nameof(user),"User not found.");
        await _repo.DeleteAsync(user!);
    }

    public async Task<IEnumerable<DisplayUser>> GetUnverified()
    {
        var users = await _repo.GetAllAsync();
        var unverified = users.Where(u => !u.IsVerified);
        return _mapper.Map<IEnumerable<DisplayUser>>(unverified);
    }
}
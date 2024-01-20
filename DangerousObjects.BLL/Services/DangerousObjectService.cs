using AutoMapper;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.DangerousObject;
using DangerousObjectsCommon.Exceptions;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Interfaces;

namespace DangerousObjectsBLL.Services;

public class DangerousObjectService  : IDangerousObjectService
{
    private readonly IMapper _mapper;
    private readonly IDangerousObjectRepo _repo;
    private readonly IUserRepo _userRepo;
    
    public DangerousObjectService(IMapper mapper, IDangerousObjectRepo repo, IUserRepo userRepo)
    {
        _mapper = mapper;
        _repo = repo;
        _userRepo = userRepo;
    }
    
    public async Task<IEnumerable<DisplayDangerousObject>> GetAll()
    {
        var dangerousObjects = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DisplayDangerousObject>>(dangerousObjects);
    }

    public async Task<DisplayDangerousObject> GetById(int id)
    {
        var dangerousObject = await _repo.FindAsync(id);
        if (dangerousObject == null)
            throw new DangerousObjectNotFoundException(nameof(dangerousObject),"Dangerous object not found.");
        return _mapper.Map<DisplayDangerousObject>(dangerousObject);
        
    }

    public async Task<DisplayDangerousObject> Create(CreateDangerousObject createDangerousObject, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var dangerousObject = _mapper.Map<DangerousObject>(createDangerousObject);
        dangerousObject.OwnerId = userId;
        dangerousObject.DateAdded = DateTime.Now;
        await _repo.AddAsync(dangerousObject);
        return _mapper.Map<DisplayDangerousObject>(dangerousObject);
    }

    public async Task<DisplayDangerousObject> Update(int id, UpdateDangerousObject updateDangerousObject, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var dangerousObject = await _repo.FindAsync(id);
        if (dangerousObject == null)
            throw new DangerousObjectNotFoundException(nameof(dangerousObject),"Dangerous object not found.");

        _mapper.Map(updateDangerousObject, dangerousObject);
        await _repo.UpdateAsync(dangerousObject!);
        return _mapper.Map<DisplayDangerousObject>(dangerousObject);
    }

    public async Task Delete(int id, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var dangerousObject = await _repo.FindAsync(id);
        if (dangerousObject == null)
            throw new DangerousObjectNotFoundException(nameof(dangerousObject),"Dangerous object not found.");
        await _repo.DeleteAsync(dangerousObject!);
    }
}
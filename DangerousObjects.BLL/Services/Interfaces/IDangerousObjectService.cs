using DangerousObjectsCommon.DTOs.DangerousObject;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IDangerousObjectService
{
    Task<IEnumerable<DisplayDangerousObject>> GetAll();
    Task<DisplayDangerousObject> GetById(int id);
    Task<DisplayDangerousObject> Create(CreateDangerousObject createDangerousObject, int userId);
    Task<DisplayDangerousObject> Update(int id, UpdateDangerousObject updateDangerousObject, int userId);
    Task Delete(int id, int userId);
}
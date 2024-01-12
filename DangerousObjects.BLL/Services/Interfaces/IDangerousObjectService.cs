using DangerousObjectsCommon.DTOs.DangerousObject;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IDangerousObjectService
{
    Task<IEnumerable<DisplayDangerousObject>> GetAll();
    Task<DisplayDangerousObject> GetById(int id);
    Task<DisplayDangerousObject> Create(CreateDangerousObject createDangerousObject);
    Task<DisplayDangerousObject> Update(int id, UpdateDangerousObject updateDangerousObject);
    Task Delete(int id);
}
using DangerousObjectsCommon.DTOs.Message;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<DisplayMessage>> GetAll();
    Task<DisplayMessage> GetById(int id);
    Task<DisplayMessage> Create(CreateMessage message);
    Task<DisplayMessage> Update(int id, UpdateMessage message);
    Task Delete(int id);
}
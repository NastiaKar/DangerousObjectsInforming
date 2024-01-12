using DangerousObjectsCommon.DTOs.Message;

namespace DangerousObjectsBLL.Services.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<DisplayMessage>> GetAll();
    Task<DisplayMessage> GetById(int id);
    Task<DisplayMessage> Create(CreateMessage message, int userId);
    Task<DisplayMessage> Update(int id, UpdateMessage message, int userId);
    Task Delete(int id, int userId);
}
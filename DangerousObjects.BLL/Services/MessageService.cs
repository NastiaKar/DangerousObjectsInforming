using AutoMapper;
using DangerousObjectsBLL.Services.Interfaces;
using DangerousObjectsCommon.DTOs.Message;
using DangerousObjectsCommon.Exceptions;
using DangerousObjectsDAL.Entities;
using DangerousObjectsDAL.Repositories.Interfaces;

namespace DangerousObjectsBLL.Services;

public class MessageService : IMessageService
{
    private readonly IMapper _mapper;
    private readonly IMessageRepo _repo;
    
    public MessageService(IMessageRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayMessage>> GetAll()
    {
        var message = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DisplayMessage>>(message);
    }

    public async Task<DisplayMessage> GetById(int id)
    {
        var message = await _repo.FindAsync(id);
        if (message == null)
            throw new MessageNotFoundException(nameof(message), "Message not found.");
        return _mapper.Map<DisplayMessage>(message);
    }

    public async Task<DisplayMessage> Create(CreateMessage message)
    {
        var messageEntity = _mapper.Map<Message>(message);
        await _repo.AddAsync(messageEntity);
        return _mapper.Map<DisplayMessage>(messageEntity);
    }

    public async Task<DisplayMessage> Update(int id, UpdateMessage message)
    {
        var messageEntity = await _repo.FindAsync(id);
        if (messageEntity == null)
            throw new MessageNotFoundException(nameof(messageEntity), "Message not found.");

        _mapper.Map(message, messageEntity);
        await _repo.UpdateAsync(messageEntity!);
        return _mapper.Map<DisplayMessage>(messageEntity);
    }

    public async Task Delete(int id)
    {
        var message = await _repo.FindAsync(id);
        if (message == null)
            throw new MessageNotFoundException(nameof(message), "Message not found.");
        await _repo.DeleteAsync(message!);
    }
}
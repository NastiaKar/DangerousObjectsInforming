﻿using AutoMapper;
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
    private readonly IUserRepo _userRepo;
    
    public MessageService(IMessageRepo repo, IMapper mapper, IUserRepo userRepo)
    {
        _repo = repo;
        _mapper = mapper;
        _userRepo = userRepo;
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

    public async Task<DisplayMessage> Create(CreateMessage message, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var messageEntity = _mapper.Map<Message>(message);
        messageEntity.SenderId = userId;
        messageEntity.DateSent = DateTime.Now;
        await _repo.AddAsync(messageEntity);
        return _mapper.Map<DisplayMessage>(messageEntity);
    }

    public async Task<DisplayMessage> Update(int id, UpdateMessage message, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var messageEntity = await _repo.FindAsync(id);
        if (messageEntity == null)
            throw new MessageNotFoundException(nameof(messageEntity), "Message not found.");

        _mapper.Map(message, messageEntity);
        await _repo.UpdateAsync(messageEntity!);
        return _mapper.Map<DisplayMessage>(messageEntity);
    }

    public async Task Delete(int id, int userId)
    {
        var user = await _userRepo.FindByIdAsync(userId);
        if (!user.IsVerified)
            throw new UserNotVerifiedException(nameof(user), "User is not verified.");
        
        var message = await _repo.FindAsync(id);
        if (message == null)
            throw new MessageNotFoundException(nameof(message), "Message not found.");
        await _repo.DeleteAsync(message!);
    }
}
using DangerousObjects.MVC.Helpers.DTOs;
using DangerousObjects.MVC.Models;

namespace DangerousObjects.MVC.Services.Interfaces;

public interface IUserService
{
    Task<GetUnverifiedUsersResultDto> GetUnverifiedUsers(string token);
    Task<bool> VerifyUser(int id, string token);
    Task<FullUserModel?> GetUserProfile(string token);
    Task<List<DangerousObjectModel>> GetDangerousObjects(string token);
    Task<bool> AddDangerousObject(DangerousObjectModel model);
    public Task<List<MessageModel>> GetMessages(string token);
    public Task<bool> AddMessage(MessageModel model);
}
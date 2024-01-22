using DangerousObjects.MVC.Helpers.Enums;
using DangerousObjects.MVC.Models;

namespace DangerousObjects.MVC.Helpers.DTOs;

public class GetUnverifiedUsersResultDto
{
    public ResponseResultEnum ResponseResult { get; set; }
    public List<FullUserModel> FullUserModels { get; set; }
}
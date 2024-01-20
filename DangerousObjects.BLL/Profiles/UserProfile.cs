using AutoMapper;
using DangerousObjectsCommon.DTOs.User;
using DangerousObjectsDAL.Entities;

namespace DangerousObjectsBLL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, DisplayUser>();
        CreateMap<UpdateUser, User>();
    }
}
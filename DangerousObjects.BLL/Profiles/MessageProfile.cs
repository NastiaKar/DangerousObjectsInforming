using AutoMapper;
using DangerousObjectsBLL.Extensions;
using DangerousObjectsCommon.DTOs.Message;
using DangerousObjectsCommon.Enums;
using DangerousObjectsDAL.Entities;

namespace DangerousObjectsBLL.Profiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DangerousObjectProfile())));
        
        CreateMap<Message, DisplayMessage>()
            .ForMember(dest => dest.SenderId,
                opt => opt.MapFrom(src => src.SenderId))
            .ForMember(dest => dest.DangerousObjectId,
                opt => opt.MapFrom(src => src.DangerousObjectId));


        CreateMap<CreateMessage, Message>()
            .ForMember(dest => dest.DateSent,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Importance,
                opt => opt.MapFrom(src => src.Importance.ConvertToImportance()));
        
        CreateMap<UpdateMessage, Message>()
            .ForMember(dest => dest.Importance,
                opt => opt.MapFrom(src => src.Importance.ConvertToImportance()));
    }
}
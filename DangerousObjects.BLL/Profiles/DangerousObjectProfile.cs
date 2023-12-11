using AutoMapper;
using DangerousObjectsBLL.Extensions;
using DangerousObjectsCommon.DTOs.DangerousObject;
using DangerousObjectsDAL.Entities;

namespace DangerousObjectsBLL.Profiles;

public class DangerousObjectProfile : Profile
{
    public DangerousObjectProfile()
    {
        CreateMap<DangerousObject, DisplayDangerousObject>()
            .ForMember(dest => dest.OwnerId, 
                opt => opt.MapFrom(src => src.Owner.Id));
        
        
        CreateMap<CreateDangerousObject, DangerousObject>()
            .ForMember(dest => dest.ObjType, 
                opt => opt.MapFrom(src => src.ObjType.ConvertToObjType()));
        
        CreateMap<UpdateDangerousObject, DangerousObject>()
            .ForMember(dest => dest.ObjType, 
                opt => opt.MapFrom(src => src.ObjType.ConvertToObjType()));
    }
}
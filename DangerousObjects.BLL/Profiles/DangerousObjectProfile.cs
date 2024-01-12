using AutoMapper;
using DangerousObjectsBLL.Extensions;
using DangerousObjectsCommon.DTOs.DangerousObject;
using DangerousObjectsDAL.Entities;

namespace DangerousObjectsBLL.Profiles;

public class DangerousObjectProfile : Profile
{
    public DangerousObjectProfile()
    {
        CreateMap<DangerousObject, DisplayDangerousObject>();
        
        CreateMap<CreateDangerousObject, DangerousObject>()
            .ForMember(dest => dest.ObjType, 
                opt => opt.MapFrom(src => src.ObjType.ConvertToObjType()));
        
        CreateMap<UpdateDangerousObject, DangerousObject>()
            .ForMember(dest => dest.ObjType, 
                opt => opt.MapFrom(src => src.ObjType.ConvertToObjType()));
    }
}
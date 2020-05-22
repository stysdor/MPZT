using AutoMapper;
using MPZT.GUI.DataAccess;
using MPZT.GUI.Models;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Mappers
{
    public static class AutoMapperConfig
    {

        public static IMapper Initialize() => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<GeoPointModel, GeoPointDto>().ReverseMap();
            cfg.CreateMap<GeoPointSearchModel, GeoPointSearchDto>().ReverseMap();
            cfg.CreateMap<LocationModel, LocationDto>().ReverseMap();
            cfg.CreateMap<AreaDto, AreaModel>().ReverseMap();
            cfg.CreateMap<ProposalModel, ProposalDto>().ReverseMap();
            cfg.CreateMap<CommentModel, CommentDto>().ReverseMap();
            cfg.CreateMap<ProjectFileModel, ProjectFileDto>().ReverseMap();
            cfg.CreateMap<ProjectModel, ProjectDto>().ForMember(x => x.Files, m=> m.MapFrom(p => p.Files))
                                                    .ReverseMap();
            cfg.CreateMap<RoleDto, Role>().ForMember(x => x.RoleId, m => m.MapFrom(p => p.Id))
                                           .ForMember(x => x.RoleName, m => m.MapFrom(p => p.Name))
                                           .ReverseMap();
            cfg.CreateMap<UserDto, User>().ReverseMap();
        }).CreateMapper();
    }
}
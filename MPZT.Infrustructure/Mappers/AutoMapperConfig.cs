using AutoMapper;
using MPZT.Core.Domain;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Mappers
{

    public static class AutoMapperConfig
    {

        public static IMapper Initialize() => new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<GeoPoint, GeoPointDto>().ReverseMap(); 
            cfg.CreateMap<Location, LocationDto>().ReverseMap(); 
            cfg.CreateMap<AreaMPZT, AreaDto>().ForMember(x => x.OfficeId, m => m.MapFrom(p => p.Office.Id))
                                              .ForMember(x => x.PhaseId, m => m.MapFrom(p => p.Phase.Id))
                                              .ReverseMap();
            cfg.CreateMap<Role, RoleDto>().ReverseMap();
            cfg.CreateMap<User, UserDto>().ReverseMap();
            cfg.CreateMap<Proposal, ProposalDto>().ForMember(x=> x.AreaId, m=> m.MapFrom(p => p.AreaMPZT.Id))
                                                  .ForMember(x=> x.UserName, m=>m.MapFrom(p=> p.User.UserName))
                                                  .ForMember(x => x.UserId, m => m.MapFrom(p => p.User.Id))
                                                  .ReverseMap();
            cfg.CreateMap<Comment, CommentDto>().ForMember(x => x.ProjectId, m => m.MapFrom(p => p.Project.Id))
                                                  .ForMember(x => x.UserName, m => m.MapFrom(p => p.User.UserName))
                                                  .ForMember(x => x.UserId, m => m.MapFrom(p => p.User.Id))
                                                  .ReverseMap();
            cfg.CreateMap<ProjectFile, ProjectFileDto>().ForMember(x => x.ProjectId, m => m.MapFrom(p => p.Project.Id))
                                                        .ReverseMap();
            cfg.CreateMap<Project, ProjectDto>().ForMember(x=> x.AreaId, m=> m.MapFrom(p=> p.AreaMPZT.Id))
                                                .ReverseMap();
            
        }).CreateMapper();
    }
}

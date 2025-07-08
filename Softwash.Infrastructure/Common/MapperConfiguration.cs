
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;

namespace Softwash.Infrastructure.Common;
public class MapperConfiguration : AutoMapper.Profile
{
    public MapperConfiguration()
    {
        #region Auth

        //CreateMap<Destionation, Sourece(DTO)>ReverseMap();
        CreateMap<Softwash.Domain.Entities.User, UserProfileDTO>().ReverseMap()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
        #endregion


        CreateMap<Project, ProjectRequestDTO>().ReverseMap();

        CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            

        CreateMap<Project, ProjectDetailDTO>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

        CreateMap<ProjectTask, ProjectTaskResponseDTO>().ReverseMap();
        CreateMap<ProjectTask, ProjectTaskRequestDTO>().ReverseMap();
        CreateMap<ProjectTask, UpdateTaskRequestDTO>().ReverseMap();

    }
}

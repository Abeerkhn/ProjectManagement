using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using ProjectManagement.Infrastructure.Services.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<OutputDTO<object>>
    {
        public ProjectFilterDTO dto { get; set; }

       
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public GetAllProjectsQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetAll(request.dto);
        }
    }
}

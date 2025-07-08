using ProjectManagement.Infrastructure.Services.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<OutputDTO<object>>
    {
        public long Id { get; set; }

        
    }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public GetProjectByIdQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetById(request.Id);
        }
    }
}

using ProjectManagement.Infrastructure.Services.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<OutputDTO<object>>
    {
        public long ProjectId { get; set; }

        
    }
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public DeleteProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.Delete(request.ProjectId);
        }
    }
}

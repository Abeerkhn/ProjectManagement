using ProjectManagement.Infrastructure.Services.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<OutputDTO<object>>
    {
        public long TaskId { get; set; }

      
    }
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public DeleteTaskCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.DeleteTask(request.TaskId);
        }
    }
}

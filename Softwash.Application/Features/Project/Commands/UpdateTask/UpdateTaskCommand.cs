using ProjectManagement.Infrastructure.Services.ProjectModule;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<OutputDTO<object>>
    {
        public UpdateTaskRequestDTO Dto { get; set; }

       
    }
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public UpdateTaskCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.UpdateTask(request.Dto);
        }
    }
}

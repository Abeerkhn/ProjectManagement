using ProjectManagement.Infrastructure.Services.ProjectModule;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.AddTaskToProject
{
    public class AddTaskToProjectCommand : IRequest<OutputDTO<object>>
    {
        public ProjectTaskRequestDTO Dto { get; set; }

       
    }
    public class AddTaskToProjectCommandHandler : IRequestHandler<AddTaskToProjectCommand, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;

        public AddTaskToProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<OutputDTO<object>> Handle(AddTaskToProjectCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.AddTaskToProject(request.Dto);
        }
    }

}

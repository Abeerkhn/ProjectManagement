using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using ProjectManagement.Infrastructure.Services.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<OutputDTO<object>>
    {
        public ProjectRequestDTO Dto { get; set; }

        
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, OutputDTO<object>>
    {
        private readonly IProjectService _projectService;
        private readonly IValidator<ProjectRequestDTO> _validator;

        public CreateProjectCommandHandler(
            IProjectService projectService,
            IValidator<ProjectRequestDTO> validator)
        {
            _projectService = projectService;
            _validator = validator;
        }

        public async Task<OutputDTO<object>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Dto, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Output.Handler<object>((int)ResponseType.CUSTOM_ERROR, 0, "Request is invalid");
            }

            return await _projectService.Save(request.Dto);
        }
    }
}


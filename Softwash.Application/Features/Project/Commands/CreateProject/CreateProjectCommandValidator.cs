using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<ProjectRequestDTO>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(100).WithMessage("Project name must not exceed 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be after start date.");
        }
    }
}



using ProjectManagement.Application.Features.Project.Commands.CreateProject;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Stripe;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;

namespace Softwash.Application;
public static class ServiceExtension
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<IValidator<ProjectRequestDTO>, CreateProjectCommandValidator>();

        return services;
    }

}

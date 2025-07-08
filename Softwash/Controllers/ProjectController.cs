using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Features.Project.Commands.AddTaskToProject;
using ProjectManagement.Application.Features.Project.Commands.CreateProject;
using ProjectManagement.Application.Features.Project.Commands.DeleteProject;
using ProjectManagement.Application.Features.Project.Commands.DeleteTask;
using ProjectManagement.Application.Features.Project.Commands.UpdateTask;
using ProjectManagement.Application.Features.Project.Queries.GetAllProjects;
using ProjectManagement.Application.Features.Project.Queries.GetProjectById;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;

namespace ProjectManagement.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /api/projects
        [HttpGet]
        public async Task<ActionResult<OutputDTO<object>>> GetAllProjects([FromQuery] ProjectFilterDTO dto)
        {
            var result = await _mediator.Send(new GetAllProjectsQuery { dto = dto });
            return Ok(result);
        }

        // GET: /api/projects/{id}
        [HttpGet("{id:long}")]
        public async Task<ActionResult<OutputDTO<object>>> GetProjectById(long id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery { Id = id });
            return Ok(result);
        }

        // POST: /api/projects
        [HttpPost]
        public async Task<ActionResult<OutputDTO<long>>> CreateProject([FromBody] ProjectRequestDTO dto)
        {
            var result = await _mediator.Send(new CreateProjectCommand() { Dto=dto});
            return Ok(result);
        }

        // PUT: /api/projects/{id}
        [HttpPut("{id:long}")]
        public async Task<ActionResult<OutputDTO<long>>> UpdateProject(long id, [FromBody] ProjectRequestDTO dto)
        {
            dto.Id = id;
            var result = await _mediator.Send(new CreateProjectCommand() { Dto = dto }); // same command handles both create and update
            return Ok(result);
        }

        // DELETE: /api/projects/{id}
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<OutputDTO<object>>> DeleteProject(long id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand() { ProjectId=id});
            return Ok(result);
        }

        // POST: /api/projects/{projectId}/tasks
        [HttpPost("{projectId:long}/tasks")]
        public async Task<ActionResult<OutputDTO<object>>> AddTaskToProject(long projectId, [FromBody] ProjectTaskRequestDTO dto)
        {
            dto.ProjectId = projectId;
            var result = await _mediator.Send(new AddTaskToProjectCommand() { Dto=dto});
            return Ok(result);
        }

        // PUT: /api/tasks/{id}
        [HttpPut("/api/tasks/{id:long}")]
        public async Task<ActionResult<OutputDTO<object>>> UpdateTask(long id, [FromBody] UpdateTaskRequestDTO dto)
        {
            dto.Id = id;
            var result = await _mediator.Send(new UpdateTaskCommand() { Dto = dto });
            return Ok(result);
        }

        // DELETE: /api/tasks/{id}
        [HttpDelete("/api/tasks/{id:long}")]
        public async Task<ActionResult<OutputDTO<object>>> DeleteTask(long id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand() { TaskId=id});
            return Ok(result);
        }
    }
}

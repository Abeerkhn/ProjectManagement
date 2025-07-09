

namespace ProjectManagement.Controllers
{
    /// <summary>
    /// Manages project-related operations.
    /// </summary>
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a paginated list of projects.
        /// </summary>
        /// <param name="dto">Filter options for the projects.</param>
        /// <returns>A list of projects.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        public async Task<ActionResult<OutputDTO<object>>> GetAllProjects([FromQuery] ProjectFilterDTO dto)
        {
            var result = await _mediator.Send(new GetAllProjectsQuery { dto = dto });
            return Ok(result);
        }

        /// <summary>
        /// Gets a project by ID.
        /// </summary>
        /// <param name="id">Project ID.</param>
        /// <returns>The project details including tasks.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        public async Task<ActionResult<OutputDTO<object>>> GetProjectById(long id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="dto">Project data.</param>
        /// <returns>The ID of the newly created project.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OutputDTO<long>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        public async Task<ActionResult<OutputDTO<long>>> CreateProject([FromBody] ProjectRequestDTO dto)
        {
            var result = await _mediator.Send(new CreateProjectCommand { Dto = dto });
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="id">Project ID.</param>
        /// <param name="dto">Updated project data.</param>
        /// <returns>The ID of the updated project.</returns>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(OutputDTO<long>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]
        public async Task<ActionResult<OutputDTO<long>>> UpdateProject(long id, [FromBody] ProjectRequestDTO dto)
        {
            dto.Id = id;
            var result = await _mediator.Send(new CreateProjectCommand { Dto = dto });
            return Ok(result);
        }

        /// <summary>
        /// Deletes a project.
        /// </summary>
        /// <param name="id">Project ID.</param>
        /// <returns>Success message or error.</returns>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]
        public async Task<ActionResult<OutputDTO<object>>> DeleteProject(long id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand { ProjectId = id });
            return Ok(result);
        }

        /// <summary>
        /// Adds a task to a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="dto">Task details.</param>
        /// <returns>Success or error response.</returns>
        [HttpPost("{projectId:long}/tasks")]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]
        public async Task<ActionResult<OutputDTO<object>>> AddTaskToProject(long projectId, [FromBody] ProjectTaskRequestDTO dto)
        {
            dto.ProjectId = projectId;
            var result = await _mediator.Send(new AddTaskToProjectCommand { Dto = dto });
            return Ok(result);
        }

        /// <summary>
        /// Updates a task.
        /// </summary>
        /// <param name="id">Task ID.</param>
        /// <param name="dto">Updated task details.</param>
        /// <returns>Success or error response.</returns>
        [HttpPut("/api/tasks/{id:long}")]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 400)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]
        public async Task<ActionResult<OutputDTO<object>>> UpdateTask(long id, [FromBody] UpdateTaskRequestDTO dto)
        {
            dto.Id = id;
            var result = await _mediator.Send(new UpdateTaskCommand { Dto = dto });
            return Ok(result);
        }

        /// <summary>
        /// Deletes a task.
        /// </summary>
        /// <param name="id">Task ID.</param>
        /// <returns>Success or error response.</returns>
        [HttpDelete("/api/tasks/{id:long}")]
        [ProducesResponseType(typeof(OutputDTO<object>), 200)]
        [ProducesResponseType(typeof(OutputDTO<object>), 404)]

        public async Task<ActionResult<OutputDTO<object>>> DeleteTask(long id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand { TaskId = id });
            return Ok(result);
        }
    }
}

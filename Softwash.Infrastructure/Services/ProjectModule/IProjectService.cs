using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services.ProjectModule
{
    public interface IProjectService
    {

        Task<OutputDTO<object>> GetAll(ProjectFilterDTO dto);
        Task<OutputDTO<object>> GetById(long id);
        Task<OutputDTO<object>> Save( ProjectRequestDTO command);
       
        Task<OutputDTO<object>> Delete(long id);

        // Task endpoints
        Task<OutputDTO<object>> AddTaskToProject(ProjectTaskRequestDTO command);
        Task<OutputDTO<object>> UpdateTask(UpdateTaskRequestDTO command);
        Task<OutputDTO<object>> DeleteTask(long taskId);
    }
}

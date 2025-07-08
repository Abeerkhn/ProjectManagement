using AutoMapper;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Services.ProjectModule.DTOs;
using Softwash.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services.ProjectModule
{
    public class ProjectService(IUnitOfWork unitOfWork, IMapper mapper) : IProjectService

    {
        readonly IUnitOfWork _unitOfWork = unitOfWork;
        readonly IMapper _mapper = mapper;
        const string projectTaskEntity = "ProjectTask";
        const string projectEntity = "Project";

        public async Task<OutputDTO<object>> AddTaskToProject(ProjectTaskRequestDTO command)
        {
           

            var project = await _unitOfWork.ProjectRepo.Get(command.ProjectId);
            if (project == null || project.IsDeleted)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, "Project");

            var taskExists = await _unitOfWork.ProjectTaskRepo.AsQueryable()
                .AnyAsync(x => x.ProjectId == command.ProjectId && x.Title == command.Title && !x.IsDeleted);

            if (taskExists)
                return Output.Handler<object>((int)ResponseType.ALREADY_EXIST, false, projectTaskEntity);

            var task = _mapper.Map<ProjectTask>(command);
            task.CreatedDate = DateTime.UtcNow;
            task.IsDeleted = false;

            await _unitOfWork.ProjectTaskRepo.AddAsync(task);
            await _unitOfWork.Save();

            return Output.Handler<object>((int)ResponseType.CREATE, true, projectTaskEntity);
        }

        public async Task<OutputDTO<object>> Delete(long id)
        {
          
            var project = await _unitOfWork.ProjectRepo.Get(id);
            if (project == null || project.IsDeleted)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, projectEntity);

            project.IsDeleted = true;
            project.ModifiedDate = DateTime.UtcNow;

            // Optionally soft-delete associated tasks too
            var tasks = await _unitOfWork.ProjectTaskRepo
                .AsQueryable()
                .Where(t => t.ProjectId == id && !t.IsDeleted)
                .ToListAsync();

            foreach (var task in tasks)
            {
                task.IsDeleted = true;
                task.ModifiedDate = DateTime.UtcNow;
            }

            await _unitOfWork.ProjectRepo.UpdateAsync(project);
            await _unitOfWork.ProjectTaskRepo.UpdateRangeEntity(tasks);
            await _unitOfWork.Save();

            return Output.Handler<object>((int)ResponseType.DELETE, true, projectEntity);
        }


        public async Task<OutputDTO<object>> DeleteTask(long taskId)
        {
            
            var task = await _unitOfWork.ProjectTaskRepo.Get(taskId);
            if (task == null || task.IsDeleted)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, projectTaskEntity);

            task.IsDeleted = true;
            task.ModifiedDate = DateTime.UtcNow;

            await _unitOfWork.ProjectTaskRepo.UpdateAsync(task);
            await _unitOfWork.Save();

            return Output.Handler<object>((int)ResponseType.DELETE, true, projectTaskEntity);
        }

        public async Task<OutputDTO<object>> GetAll(ProjectFilterDTO dto)
        {
            const string entity = "Project";

            dto.SortBy = string.IsNullOrEmpty(dto.SortBy) ? "Id" : dto.SortBy;
            dto.SortDirection = string.IsNullOrEmpty(dto.SortDirection) ? "DESC" : dto.SortDirection;

            var filter = PredicateBuilder.True<Project>();

            if (dto.Id is not null)
                filter = filter.And(x => x.Id == dto.Id);

            if (!string.IsNullOrEmpty(dto.Name))
                filter = filter.And(x => x.Name.Contains(dto.Name));

            if (dto.CreatedById is not null)
                filter = filter.And(x => x.CreatedById == dto.CreatedById);

            if (dto.IsDeleted is not null)
                filter = filter.And(x => x.IsDeleted == dto.IsDeleted);

            #region Date Range
            if (dto.StartDate is null && dto.EndDate is null) { }
            else if (dto.StartDate is not null && dto.EndDate is not null)
                filter = filter.And(x =>
                    x.StartDate.Date >= dto.StartDate.Value.Date &&
                    x.StartDate.Date <= dto.EndDate.Value.Date);
            else
            {
                var date = dto.StartDate ?? dto.EndDate;
                filter = filter.And(x => x.StartDate.Date == date.Value.Date);
            }
            #endregion

            var data = _unitOfWork.ProjectRepo.AsQueryable().AsNoTracking()
                .Where(filter)
                .Select(x => new ProjectResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                   CreatedById = x.CreatedById.Value
                });

            var totalCount = await data.CountAsync();
            if (totalCount is 0)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, new List<ProjectResponseDTO>(), entity);

            List<ProjectResponseDTO> list;
            if (dto.IsPagination)
                list = await data.ApplySorting(dto.SortBy, dto.SortDirection).ToPaggedListAsync(dto.PageNo, dto.Size);
            else
                list = await data.ApplySorting(dto.SortBy, dto.SortDirection).ToListAsync();

            return Output.Handler<object>(
                dto.Id == 0 || dto.Id is null ? (int)ResponseType.GET_ALL : (int)ResponseType.GET,
                list,
                entity,
                totalCount);
        }


        public async Task<OutputDTO<object>> GetById(long id)
        {

            var project = await _unitOfWork.ProjectRepo
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new ProjectDetailDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    CreatedById = x.CreatedById.Value,
                    Tasks = x.Tasks
                        .Where(t => !t.IsDeleted)
                        .Select(t => new ProjectTaskResponseDTO
                        {
                            Id = t.Id,
                            Title = t.Title,
                            IsCompleted = t.IsCompleted,
                            DueDate = t.DueDate
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            if (project is null)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, null, projectEntity);

            return Output.Handler<object>((int)ResponseType.GET, project, projectEntity);
        }


        public async Task<OutputDTO<object>> Save(ProjectRequestDTO dto)
        {
            
            // CREATE
            if (dto.Id is null or 0)
            {
                var exists = await _unitOfWork.ProjectRepo
                    .AsQueryable()
                    .AnyAsync(x => x.Name == dto.Name && !x.IsDeleted);
                if (exists)
                    return Output.Handler<object>((int)ResponseType.ALREADY_EXIST, false, projectEntity);

                var project = _mapper.Map<Project>(dto);
                project.CreatedDate = DateTime.UtcNow;
                project.IsDeleted = false;

                await _unitOfWork.ProjectRepo.AddAsync(project);
                await _unitOfWork.Save();

                return Output.Handler<object>((int)ResponseType.CREATE, true, projectEntity);
            }

            // UPDATE
            else if (dto.Id > 0)
            {
                var record = await _unitOfWork.ProjectRepo.Get(dto.Id.Value);
                if (record == null || record.IsDeleted)
                    return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, projectEntity);

                var duplicate = await _unitOfWork.ProjectRepo
                    .AsQueryable()
                    .AnyAsync(x => x.Name == dto.Name && x.Id != dto.Id && !x.IsDeleted);

                if (duplicate)
                    return Output.Handler<object>((int)ResponseType.ALREADY_EXIST, false, projectEntity);

                var updated = _mapper.Map(dto, record); // updates in-place
                updated.ModifiedDate = DateTime.UtcNow;

                await _unitOfWork.ProjectRepo.UpdateAsync(updated);
                await _unitOfWork.Save();

                return Output.Handler<object>((int)ResponseType.UPDATE, true, projectEntity);
            }

            return Output.Handler<object>((int)ResponseType.INVALID_REQUEST, false, projectEntity);
        }

        public async Task<OutputDTO<object>> UpdateTask(UpdateTaskRequestDTO command)
        {
            
            var task = await _unitOfWork.ProjectTaskRepo.Get(command.Id);
            if (task == null || task.IsDeleted)
                return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, projectTaskEntity);

            // Optional: check if a task with the same title already exists in the same project
            if (!string.Equals(task.Title, command.Title, StringComparison.OrdinalIgnoreCase))
            {
                var duplicate = await _unitOfWork.ProjectTaskRepo.AsQueryable()
                    .AnyAsync(x => x.ProjectId == task.ProjectId &&
                                   x.Title == command.Title &&
                                   !x.IsDeleted &&
                                   x.Id != command.Id);

                if (duplicate)
                    return Output.Handler<object>((int)ResponseType.ALREADY_EXIST, false, projectTaskEntity);
            }

            // Map updated fields
            task.Title = command.Title;
            task.DueDate = command.DueDate;
            task.IsCompleted = command.IsCompleted;
            task.ModifiedDate = DateTime.UtcNow;

            await _unitOfWork.ProjectTaskRepo.UpdateAsync(task);
            await _unitOfWork.Save();

            return Output.Handler<object>((int)ResponseType.UPDATE, true, projectTaskEntity);
        }



    }
}

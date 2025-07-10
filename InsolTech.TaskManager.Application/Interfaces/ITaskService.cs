using InsolTech.TaskManager.Application.DTOs;
using InsolTech.TaskManager.Application.Common;

namespace InsolTech.TaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<Guid> CreateAsync(TaskCreateDto dto);
        Task UpdateAsync(Guid id, TaskUpdateDto dto);
        Task DeleteAsync(Guid id);

        Task<TaskDto> GetAsync(Guid id);
        Task<PaginatedList<TaskDto>> GetAsync(int page, int size);
    }
}
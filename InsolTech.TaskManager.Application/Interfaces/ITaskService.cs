using InsolTech.TaskManager.Application.DTOs;
using InsolTech.TaskManager.Application.Common;

namespace InsolTech.TaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<Guid> CreateAsync(TaskDto dto);
        Task UpdateAsync(Guid id, TaskDto dto);
        Task DeleteAsync(Guid id);

        Task<PaginatedList<TaskDto>> GetAsync(int page, int size);
        Task<TaskDto> GetAsync(Guid id);
    }
}
using InsolTech.TaskManager.Domain.Entities;

namespace InsolTech.TaskManager.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task AddAsync(TodoItem task);
        void Update(TodoItem task);
        void Delete(TodoItem task);
        Task<int> SaveChangesAsync();

        Task<TodoItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<TodoItem>> GetAllAsync(int page, int pageSize);
    }
}
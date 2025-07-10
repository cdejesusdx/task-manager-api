using InsolTech.TaskManager.Domain.Entities;


namespace InsolTech.TaskManager.Domain.Repositories
{
    /// <summary>
    /// Contrato del repositorio de TaskItems.
    /// </summary>
    public interface ITaskRepository
    {
        Task AddAsync(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);
        Task<int> SaveChangesAsync();

        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllAsync(int page, int pageSize);

        // Helper para consultas compuestas (paginación, filtros, etc.)
        IQueryable<TaskItem> AsQueryable();
    }
}
using Microsoft.EntityFrameworkCore;

using InsolTech.TaskManager.Domain.Entities;
using InsolTech.TaskManager.Infrastructure.Data;
using InsolTech.TaskManager.Domain.Repositories;

namespace InsolTech.TaskManager.Infrastructure.Repositories
{
    internal class TaskRepository(TaskDbContext context) : ITaskRepository
    {
        private readonly TaskDbContext _context = context;

        public async Task AddAsync(TaskItem task) => await _context.Tasks.AddAsync(task);
        public void Update(TaskItem task) => _context.Tasks.Update(task);
        public void Delete(TaskItem task) => _context.Tasks.Remove(task);
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public Task<TaskItem?> GetByIdAsync(Guid id) => _context.Tasks.FindAsync(id).AsTask();
        public async Task<IEnumerable<TaskItem>> GetAllAsync(int page, int size) =>
            await _context.Tasks.OrderBy(t => t.CreatedAt)
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToListAsync();

        /* ---------- Helper ---------- */
        public IQueryable<TaskItem> AsQueryable() => _context.Tasks.AsQueryable();
    }
}
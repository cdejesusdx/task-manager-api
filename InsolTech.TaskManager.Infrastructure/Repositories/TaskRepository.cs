using Microsoft.EntityFrameworkCore;

using InsolTech.TaskManager.Domain.Entities;
using InsolTech.TaskManager.Infrastructure.Data;
using InsolTech.TaskManager.Domain.Repositories;

namespace InsolTech.TaskManager.Infrastructure.Repositories
{
    internal class TaskRepository(TaskDbContext context) : ITaskRepository
    {
        private readonly TaskDbContext _context = context;

        // public TaskDbContext Context { get; } = context;

        public async Task AddAsync(TodoItem task) => await _context.Tasks.AddAsync(task);
        public void Update(TodoItem task) => _context.Tasks.Update(task);
        public void Delete(TodoItem task) => _context.Tasks.Remove(task);
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public Task<TodoItem?> GetByIdAsync(Guid id) => _context.Tasks.FindAsync(id).AsTask();
        public async Task<IEnumerable<TodoItem>> GetAllAsync(int page, int size) =>
            await _context.Tasks.OrderBy(t => t.CreatedAt)
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToListAsync();
    }
}
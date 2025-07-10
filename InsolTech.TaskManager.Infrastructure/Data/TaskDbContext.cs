using Microsoft.EntityFrameworkCore;

using InsolTech.TaskManager.Domain.Entities;

namespace InsolTech.TaskManager.Infrastructure.Data
{
    public class TaskDbContext(DbContextOptions<TaskDbContext> opts) : DbContext(opts)
    {
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
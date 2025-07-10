using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using InsolTech.TaskManager.Domain.Repositories;
using InsolTech.TaskManager.Infrastructure.Data;
using InsolTech.TaskManager.Infrastructure.Repositories;

namespace InsolTech.TaskManager.Infrastructure.Extensions
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
            services.AddDbContext<TaskDbContext>(o => o.UseInMemoryDatabase("TaskManagerDb"))
                    .AddScoped<ITaskRepository, TaskRepository>();
    }
}
using Microsoft.Extensions.DependencyInjection;

using InsolTech.TaskManager.Application.Services;
using InsolTech.TaskManager.Application.Interfaces;

namespace InsolTech.TaskManager.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
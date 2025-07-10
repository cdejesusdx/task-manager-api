using InsolTech.TaskManager.Domain.Entities;
using TaskProgressStatus = InsolTech.TaskManager.Domain.Enums.TaskProgressStatus;

namespace InsolTech.TaskManager.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(TaskDbContext context)
        {
            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new TaskItem
                    {
                        Title = "Diseñar el formulario de creación",
                        Description = "Usar Reactive Forms en Angular",
                        Status = TaskProgressStatus.Pending,
                        CreatedAt = DateTime.UtcNow,
                        DueDate = DateTime.UtcNow.AddDays(3)
                    },
                    new TaskItem
                    {
                        Title = "Conectar Angular con API",
                        Description = "Testear todos los métodos del CRUD",
                        Status = TaskProgressStatus.InProgress,
                        CreatedAt = DateTime.UtcNow.AddDays(-1),
                        DueDate = DateTime.UtcNow.AddDays(2)
                    },
                    new TaskItem
                    {
                        Title = "Configurar Swagger y CORS",
                        Description = "Verificar acceso desde frontend",
                        Status = TaskProgressStatus.Completed,
                        CreatedAt = DateTime.UtcNow.AddDays(-2),
                        DueDate = DateTime.UtcNow.AddDays(-1)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
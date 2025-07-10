using TaskStatus = InsolTech.TaskManager.Domain.Enums.TaskStatus;

namespace InsolTech.TaskManager.Domain.Entities
{
    /// <summary>
    /// Representa un elemento dentro de una lista de tareas (To-Do).
    /// Contiene información como el título, descripción, estado, fecha de creación y fecha límite.
    /// Utilizado como entidad principal en el dominio de gestión de tareas.
    /// </summary>
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
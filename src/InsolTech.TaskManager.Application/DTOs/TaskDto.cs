using InsolTech.TaskManager.Domain.Enums;

namespace InsolTech.TaskManager.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskProgressStatus Status { get; set; }
    }
}
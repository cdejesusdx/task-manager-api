namespace InsolTech.TaskManager.Application.DTOs
{
    public record TaskDto(Guid Id, string Title, string? Description,
                      DateTime CreatedAt, DateTime? DueDate, TaskStatus Status);
}
using System.ComponentModel.DataAnnotations;

using InsolTech.TaskManager.Application.Validators;

using TaskStatus = InsolTech.TaskManager.Domain.Enums.TaskStatus;

namespace InsolTech.TaskManager.Application.DTOs
{
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;
        
        public string? Description { get; set; }
        
        [FutureDate(ErrorMessage = "La fecha límite debe ser futura")]
        
        public DateTime? DueDate { get; set; }
        
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
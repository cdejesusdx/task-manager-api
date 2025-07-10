using System.ComponentModel.DataAnnotations;

using InsolTech.TaskManager.Domain.Enums;
using InsolTech.TaskManager.Application.Validators;

namespace InsolTech.TaskManager.Application.DTOs
{
    public class TaskUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;
       
        public string? Description { get; set; }
        
        [FutureDate(ErrorMessage = "La fecha límite debe ser futura")]
        public DateTime? DueDate { get; set; }
        
        public TaskProgressStatus Status { get; set; }
    }
}

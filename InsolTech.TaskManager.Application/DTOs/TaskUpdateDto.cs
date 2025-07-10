using InsolTech.TaskManager.Application.Validators;
using System.ComponentModel.DataAnnotations;

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
        
        public TaskStatus Status { get; set; }
    }
}

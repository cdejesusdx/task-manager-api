using System.ComponentModel.DataAnnotations;

namespace InsolTech.TaskManager.Application.Validators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
                return date > DateTime.UtcNow;
            return true; // null es válido
        }
    }
}
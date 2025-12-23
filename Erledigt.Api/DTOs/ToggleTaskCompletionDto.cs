using System.ComponentModel.DataAnnotations;

namespace Erledigt.Api.DTOs;

public class ToggleTaskCompletionDto
{
    [Required]
    public bool IsCompleted { get; set; }
}

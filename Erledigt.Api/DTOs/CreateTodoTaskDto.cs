using System.ComponentModel.DataAnnotations;
using Erledigt.Api.Entities;

namespace Erledigt.Api.DTOs;

public class CreateTodoTaskDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [Range(typeof(TaskPriority), nameof(TaskPriority.Low), nameof(TaskPriority.High))]
    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}

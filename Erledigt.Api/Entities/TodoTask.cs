using System.ComponentModel.DataAnnotations;

namespace Erledigt.Api.Entities;

public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
}

public class TodoTask
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ApplicationUser? User { get; set; }
}

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
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }

    public ApplicationUser? User { get; set; }
}

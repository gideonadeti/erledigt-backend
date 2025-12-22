using Erledigt.Api.Data;
using Erledigt.Api.DTOs;
using Erledigt.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Erledigt.Api.Services;

public class TodoTaskService(ErledigtDbContext context) : ITodoTaskService
{
    private readonly ErledigtDbContext _context = context;

    public async Task<IEnumerable<TodoTaskDto>> GetAllTasksAsync(string userId)
    {
        var tasks = await _context
            .TodoTasks.Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return tasks.Select(MapToDto);
    }

    public async Task<TodoTaskDto?> GetTaskByIdAsync(int id, string userId)
    {
        var task = await _context.TodoTasks.FirstOrDefaultAsync(t =>
            t.Id == id && t.UserId == userId
        );

        return task == null ? null : MapToDto(task);
    }

    public async Task<TodoTaskDto> CreateTaskAsync(CreateTodoTaskDto dto, string userId)
    {
        var task = new TodoTask
        {
            UserId = userId,
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            DueDate = dto.DueDate,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow,
        };

        _context.TodoTasks.Add(task);

        await _context.SaveChangesAsync();

        return MapToDto(task);
    }

    public async Task<TodoTaskDto?> UpdateTaskAsync(int id, UpdateTodoTaskDto dto, string userId)
    {
        var task = await _context.TodoTasks.FirstOrDefaultAsync(t =>
            t.Id == id && t.UserId == userId
        );

        if (task == null)
            return null;

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Priority = dto.Priority;
        task.DueDate = dto.DueDate;
        task.IsCompleted = dto.IsCompleted;
        task.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return MapToDto(task);
    }

    public async Task<bool> DeleteTaskAsync(int id, string userId)
    {
        var task = await _context.TodoTasks.FirstOrDefaultAsync(t =>
            t.Id == id && t.UserId == userId
        );

        if (task == null)
            return false;

        _context.TodoTasks.Remove(task);

        await _context.SaveChangesAsync();

        return true;
    }

    private static TodoTaskDto MapToDto(TodoTask task)
    {
        return new TodoTaskDto
        {
            Id = task.Id,
            UserId = task.UserId,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
        };
    }
}

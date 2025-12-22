using Erledigt.Api.DTOs;

namespace Erledigt.Api.Services;

public interface ITodoTaskService
{
    Task<IEnumerable<TodoTaskDto>> GetAllTasksAsync(string userId);
    Task<TodoTaskDto?> GetTaskByIdAsync(int id, string userId);
    Task<TodoTaskDto> CreateTaskAsync(CreateTodoTaskDto dto, string userId);
    Task<TodoTaskDto?> UpdateTaskAsync(int id, UpdateTodoTaskDto dto, string userId);
    Task<bool> DeleteTaskAsync(int id, string userId);
}

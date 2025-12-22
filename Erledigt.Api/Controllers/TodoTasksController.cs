using System.Security.Claims;
using Erledigt.Api.DTOs;
using Erledigt.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Erledigt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoTasksController(ITodoTaskService todoTaskService) : ControllerBase
{
    private readonly ITodoTaskService _todoTaskService = todoTaskService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetAllTasks()
    {
        var userId = GetCurrentUserId();
        var tasks = await _todoTaskService.GetAllTasksAsync(userId);

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoTaskDto>> GetTask(int id)
    {
        var userId = GetCurrentUserId();
        var task = await _todoTaskService.GetTaskByIdAsync(id, userId);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TodoTaskDto>> CreateTask(CreateTodoTaskDto dto)
    {
        var userId = GetCurrentUserId();
        var task = await _todoTaskService.CreateTaskAsync(dto, userId);

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TodoTaskDto>> UpdateTask(int id, UpdateTodoTaskDto dto)
    {
        var userId = GetCurrentUserId();
        var task = await _todoTaskService.UpdateTaskAsync(id, dto, userId);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var userId = GetCurrentUserId();
        var deleted = await _todoTaskService.DeleteTaskAsync(id, userId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    private string GetCurrentUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException("User ID not found in token");
    }
}

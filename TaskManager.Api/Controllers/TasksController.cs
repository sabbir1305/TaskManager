using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tasks.Create;
using TaskManager.Application.Features.Tasks.Get;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTaskCommand command,
        CreateTaskHandler handler,
        CancellationToken ct)
    {
        await handler.Handle(command, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        GetTasksHandler handler,
        CancellationToken ct)
    {
        return Ok(await handler.Handle(ct));
    }
}

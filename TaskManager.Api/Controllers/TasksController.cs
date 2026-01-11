using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tasks.Create;
using TaskManager.Application.Features.Tasks.Get;

namespace TaskManager.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/tasks")]
public class TasksController : ControllerBase
{
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(
        CreateTaskCommand command,
        CreateTaskHandler handler,
        CancellationToken ct)
    {
        await handler.Handle(command, ct);
        return Ok();
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(
        GetTasksHandler handler,
        CancellationToken ct)
    {
        return Ok(await handler.Handle(ct));
    }

    [HttpGet]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> GetV2(
       GetTasksHandler handler,
       CancellationToken ct)
    {
        return Ok(await handler.Handle(ct));
    }
}

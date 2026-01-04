using TaskManager.Application.Abstractions.Persistence;

namespace TaskManager.Application.Features.Tasks.Get;

public class GetTasksHandler
{
    private readonly ITaskRepository _taskRepository;
    public GetTasksHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<List<TaskDto>> Handle(CancellationToken ct)
    {
        var tasks = await _taskRepository.GetAllAsync(ct);
        return [.. tasks.Select(t => new TaskDto(t.Id, t.Title, t.Status.ToString()))];
    }
}
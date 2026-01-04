using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Tasks.Create;

public class CreateTaskHandler
{
    private readonly ITaskRepository _taskRepository;
    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<TaskItem> Handle(CreateTaskCommand command, CancellationToken ct)
    {
        var taskItem = new TaskItem(command.Title);
        await _taskRepository.AddAsync(taskItem, ct);
        return taskItem;
    }
}
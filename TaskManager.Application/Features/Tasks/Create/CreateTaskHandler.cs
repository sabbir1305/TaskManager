using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Tasks.Create;

public class CreateTaskHandler
{
    private readonly ITaskRepository _repository;
    private readonly ITaskAssignmentStrategyResolver _resolver;

    public CreateTaskHandler(
        ITaskRepository repository,
        ITaskAssignmentStrategyResolver resolver)
    {
        _repository = repository;
        _resolver = resolver;
    }

    public async Task Handle(CreateTaskCommand command, CancellationToken ct)
    {
        var task = new TaskItem(command.Title);

        var strategy = _resolver.Resolve(command.AssignmentStrategy);
        await strategy.AssignAsync(task, ct);

        await _repository.AddAsync(task, ct);
    }
}
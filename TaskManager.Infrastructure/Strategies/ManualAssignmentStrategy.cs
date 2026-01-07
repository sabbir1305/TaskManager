using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Strategies;

public class ManualAssignmentStrategy : ITaskAssignmentStrategy
{
    public AssignmentStrategyType Type => AssignmentStrategyType.Manual;

    public Task AssignAsync(TaskItem task, CancellationToken ct)
    {
        // No-op (assigned manually later)
        return Task.CompletedTask;
    }
}

using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

public class LoadBasedAssignmentStrategy : ITaskAssignmentStrategy
{
    public AssignmentStrategyType Type => AssignmentStrategyType.LoadBased;

    public Task AssignAsync(TaskItem task, CancellationToken ct)
    {
        // TODO: pick user with least tasks
        return Task.CompletedTask;
    }
}

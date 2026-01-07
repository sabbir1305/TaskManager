using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

public class RoundRobinAssignmentStrategy : ITaskAssignmentStrategy
{
    public AssignmentStrategyType Type => AssignmentStrategyType.RoundRobin;

    public Task AssignAsync(TaskItem task, CancellationToken ct)
    {
        // TODO: pick next user in rotation
        return Task.CompletedTask;
    }
}

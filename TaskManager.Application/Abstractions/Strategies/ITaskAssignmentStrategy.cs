using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Abstractions.Strategies;

public interface ITaskAssignmentStrategy
{
    AssignmentStrategyType Type { get; }
    Task AssignAsync(TaskItem task, CancellationToken ct);
}

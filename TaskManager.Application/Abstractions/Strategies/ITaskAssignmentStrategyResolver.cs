using TaskManager.Domain.Enums;

namespace TaskManager.Application.Abstractions.Strategies;

public interface ITaskAssignmentStrategyResolver
{
    ITaskAssignmentStrategy Resolve(AssignmentStrategyType type);
}

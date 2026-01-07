using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.Create;

public record CreateTaskCommand(
    string Title,
    AssignmentStrategyType AssignmentStrategy);

using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Abstractions.Strategies;

public class TaskAssignmentStrategyResolver
    : ITaskAssignmentStrategyResolver
{
    private readonly IServiceProvider _provider;

    public TaskAssignmentStrategyResolver(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ITaskAssignmentStrategy Resolve(AssignmentStrategyType type)
    {
        return _provider.GetRequiredKeyedService<ITaskAssignmentStrategy>(type);
    }
}

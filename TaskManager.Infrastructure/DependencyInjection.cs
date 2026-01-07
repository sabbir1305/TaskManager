using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Enums;
using TaskManager.Infrastructure.Persistence;
using TaskManager.Infrastructure.Persistence.Repositories;
using TaskManager.Infrastructure.Strategies;

namespace TaskManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<TaskDbContext>(opt =>
            opt.UseInMemoryDatabase("TaskDb"));

        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddKeyedScoped<ITaskAssignmentStrategy, ManualAssignmentStrategy>(AssignmentStrategyType.Manual);

        services.AddKeyedScoped<ITaskAssignmentStrategy, RoundRobinAssignmentStrategy>(AssignmentStrategyType.RoundRobin);

        services.AddKeyedScoped<ITaskAssignmentStrategy, LoadBasedAssignmentStrategy>(AssignmentStrategyType.LoadBased);
        return services;
    }
}

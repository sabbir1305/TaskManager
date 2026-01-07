using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Abstractions.Caching;
using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Enums;
using TaskManager.Infrastructure.Caching;
using TaskManager.Infrastructure.Persistence;
using TaskManager.Infrastructure.Persistence.Repositories;
using TaskManager.Infrastructure.Strategies;
using TaskManager.Infrastructure.Strategies.Decorators;

namespace TaskManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<TaskDbContext>(opt =>
            opt.UseInMemoryDatabase("TaskDb"));
        services.AddMemoryCache();
        services.AddScoped<ICacheService, MemoryCacheService>();

        services.AddScoped<ManualAssignmentStrategy>();
        services.AddScoped<RoundRobinAssignmentStrategy>();
        services.AddScoped<LoadBasedAssignmentStrategy>();

        services.AddKeyedScoped<ITaskAssignmentStrategy>(
            AssignmentStrategyType.Manual,
            (sp, _) => new CachedTaskAssignmentStrategy(
                sp.GetRequiredService<ManualAssignmentStrategy>(),
                sp.GetRequiredService<ICacheService>())
        );

        services.AddKeyedScoped<ITaskAssignmentStrategy>(
            AssignmentStrategyType.RoundRobin,
            (sp, _) => new CachedTaskAssignmentStrategy(
                sp.GetRequiredService<RoundRobinAssignmentStrategy>(),
                sp.GetRequiredService<ICacheService>())
        );

        services.AddKeyedScoped<ITaskAssignmentStrategy>(
            AssignmentStrategyType.LoadBased,
            (sp, _) => new CachedTaskAssignmentStrategy(
                sp.GetRequiredService<LoadBasedAssignmentStrategy>(),
                sp.GetRequiredService<ICacheService>())
        );

        return services;
    }
}

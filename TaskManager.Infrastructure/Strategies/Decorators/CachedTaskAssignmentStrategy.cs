

using TaskManager.Application.Abstractions.Caching;
using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Strategies.Decorators;
public class CachedTaskAssignmentStrategy : ITaskAssignmentStrategy
{
    private readonly ITaskAssignmentStrategy inner;
    private readonly ICacheService cache;

    public CachedTaskAssignmentStrategy(ITaskAssignmentStrategy  inner, ICacheService cache)
    {
        this.inner = inner;
        this.cache = cache;
    }

    public AssignmentStrategyType Type => inner.Type;

    public async Task AssignAsync(TaskItem task, CancellationToken ct)
    {
        var cacheKey = $"assignment:{Type}:{task.Id}";
        var cached = await cache.GetAsync<bool>(cacheKey, ct);
        if(cached)
        {
            return;
        }

        await inner.AssignAsync(task, ct);
        await cache.SetAsync(cacheKey, true, TimeSpan.FromMinutes(10), ct);
    }
}

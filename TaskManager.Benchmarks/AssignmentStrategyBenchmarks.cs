using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Caching.Memory;
using TaskManager.Application.Abstractions.Caching;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Caching;
using TaskManager.Infrastructure.Strategies;
using TaskManager.Infrastructure.Strategies.Decorators;

[MemoryDiagnoser]
public class AssignmentStrategyBenchmarks
{
    private ManualAssignmentStrategy _noCacheStrategy;
    private CachedTaskAssignmentStrategy _cachedStrategy;

    [GlobalSetup]
    public void Setup()
    {
        // NO CACHE
        _noCacheStrategy = new ManualAssignmentStrategy();

        // WITH CACHE
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        ICacheService cacheService = new MemoryCacheService(memoryCache);

        _cachedStrategy = new CachedTaskAssignmentStrategy(
            new ManualAssignmentStrategy(),
            cacheService);
    }

    [Benchmark(Baseline = true)]
    public async Task AssignWithoutCache()
    {
        var task = new TaskItem("NoCache");
        await _noCacheStrategy.AssignAsync(task, CancellationToken.None);
    }

    [Benchmark]
    public async Task AssignWithCache()
    {
        var task = new TaskItem("Cached");
        await _cachedStrategy.AssignAsync(task, CancellationToken.None);
    }
}

using Microsoft.Extensions.Caching.Memory;
using TaskManager.Application.Abstractions.Caching;

namespace TaskManager.Infrastructure.Caching;
public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache cache;
    public MemoryCacheService(IMemoryCache cache)
    {
        this.cache = cache;
    }
    public Task<T?> GetAsync<T>(string key, CancellationToken ct)
    {
        _ = cache.TryGetValue(key, out T? value);
        return Task.FromResult(value);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan ttl, CancellationToken ct)
    {
        cache.Set(key, value, ttl);
        return Task.CompletedTask;
    }
}

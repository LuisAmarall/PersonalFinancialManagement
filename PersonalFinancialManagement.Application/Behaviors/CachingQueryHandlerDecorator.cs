using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Distributed;
using PersonalFinancialManagement.Application.Abstractions;

namespace PersonalFinancialManagement.Application.Behaviors;

public class CachingQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _inner;
    private readonly IDistributedCache _cache;
    private readonly TimeSpan _expiration;

    public CachingQueryHandlerDecorator(IQueryHandler<TQuery, TResult> inner, IDistributedCache cache, TimeSpan expiration)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _expiration = expiration;
    }

    public async Task<TResult> HandlerAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        var cacheKey = $"query:{typeof(TQuery).Name}:{GetQueryHash(query)}";

        var cached = await _cache.GetStringAsync(cacheKey, cancellationToken);
        if (!string.IsNullOrEmpty(cached))
            return JsonSerializer.Deserialize<TResult>(cached)!;

        var result = await _inner.HandlerAsync(query, cancellationToken);

        await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = _expiration
        }, cancellationToken);

        return result;
    }

    private string GetQueryHash(TQuery query)
    {
        return Convert.ToBase64String(MD5.HashData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query))));
    }
}
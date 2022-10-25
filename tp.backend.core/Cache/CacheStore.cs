using System.Text.Json;
using Serilog;
using tp.backend.core.Exceptions;

namespace tp.backend.core.Cache;

internal class CacheStore : ICacheStore
{
    private readonly ILogger _logger;
    private readonly IRedisMultiplexer _multiplexer;

    private readonly JsonSerializerOptions _serializerOptions;

    public CacheStore(IRedisMultiplexer multiplexer, ILogger logger)
    {
        _multiplexer = multiplexer;
        _logger = logger;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory,
        int duration = CacheDuration.Eternal)
    {
        var oldCache = await _multiplexer.Db.StringGetAsync(key);


        _logger.Information($"cache object: {typeof(TCache).Name} \n");
        if (!oldCache.IsNullOrEmpty)
            return JsonSerializer.Deserialize<TCache>(oldCache.ToString(), _serializerOptions) ??
                   throw new InvalidCastException("Cache value deserialization was null");
        try
        {
            var toBeCached = await cacheFactory();
            if (toBeCached == null) throw new InvalidDataException("Cache factory result was null");
            var result = await StoreAsync(key, toBeCached, duration);
            return result;
        }
        catch (Exception e)
        {
            _logger.Fatal($"create object to be cached failed: {typeof(TCache).Name} \n" +
                          $"exception : {e}");
            throw;
        }
    }

    public async Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached,
        int duration = CacheDuration.Eternal)
    {
        try
        {
            if (toBeCached == null) throw new InvalidDataException("Cache data is null");
            var objectString = JsonSerializer.Serialize(toBeCached, _serializerOptions);
            await _multiplexer.Db.StringSetAsync(key, objectString,
                duration == CacheDuration.Eternal
                    ? null
                    : TimeSpan.FromSeconds(duration));
            return toBeCached;
        }
        catch (Exception e)
        {
            _logger.Fatal($"object cached failed: {typeof(TCache).Name} \n" +
                          $"exception : {e}");
            throw;
        }
    }

    public async Task<bool> RemoveAsync(string key)
    {
        try
        {
            return await _multiplexer.Db.KeyDeleteAsync(key);
        }
        catch (Exception e)
        {
            _logger.Fatal($"object remove key failed with key: {key} \n" +
                          $"exception : {e}");
            throw;
        }
    }

    public async Task<bool> HasKeyAsync(string key)
    {
        try
        {
            return await _multiplexer.Db.KeyExistsAsync(key);
        }
        catch (Exception e)
        {
            _logger.Fatal($"object exist key failed with key: {key} \n" +
                          $"exception : {e}");
            throw;
        }
    }

    public async Task<TCache> Get<TCache>(string key)
    {
        try
        {
            var item = await _multiplexer.Db.StringGetAsync(key);

            if (!item.IsNullOrEmpty)
                return JsonSerializer.Deserialize<TCache>(item.ToString(), _serializerOptions) ??
                       throw new InvalidCastException("Get value deserialization was null");
            throw new NotFoundException(key);
        }
        catch (Exception e)
        {
            _logger.Fatal($"object exist key failed with key: {key} \n" +
                          $"exception : {e}");
            throw;
        }
    }
}
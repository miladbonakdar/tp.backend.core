using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace tp.shared.Cache;

public static class ConfigureCacheModuleExtension
{
    public static void AddCacheModule(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RedisSetting>(configuration.GetSection("Redis"));
        services.AddSingleton<IRedisMultiplexer, RedisMultiplexer>();
        services.AddSingleton<ICacheStore, CacheStore>();
    }
}
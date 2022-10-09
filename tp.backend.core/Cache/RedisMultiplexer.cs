using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace tp.shared.Cache;

internal class RedisMultiplexer : IRedisMultiplexer
{
    private readonly string _connectionString;
    private readonly Lazy<ConnectionMultiplexer> _lazyConnection;

    public RedisMultiplexer(IOptions<RedisSetting> options)
    {
        _connectionString = options.Value.ConnectionString;
        var configurationOptions = ConfigurationOptions.Parse(_connectionString);

        _lazyConnection = new Lazy<ConnectionMultiplexer>(
            () => ConnectionMultiplexer.Connect(configurationOptions));
    }

    public ISubscriber Subscriber => Connection.GetSubscriber();

    public ConnectionMultiplexer Connection => _lazyConnection.Value;

    public IDatabase Db => Connection.GetDatabase();

    public IServer Server => Connection.GetServer(_connectionString);
}
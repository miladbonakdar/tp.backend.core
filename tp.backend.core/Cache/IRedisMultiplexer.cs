using StackExchange.Redis;

namespace tp.backend.core.Cache;

internal interface IRedisMultiplexer
{
    ConnectionMultiplexer Connection { get; }
    IDatabase Db { get; }
    ISubscriber Subscriber { get; }
    IServer Server { get; }
}
using StackExchange.Redis;

namespace tp.shared.Cache;

internal interface IRedisMultiplexer
{
    ConnectionMultiplexer Connection { get; }
    IDatabase Db { get; }
    ISubscriber Subscriber { get; }
    IServer Server { get; }
}
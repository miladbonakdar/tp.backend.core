namespace tp.shared.Cache;

public interface ICacheStore
{
    Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory,
        int duration = CacheDuration.Eternal);

    Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached,
        int duration = CacheDuration.Eternal);

    Task<bool> RemoveAsync(string key);
    Task<bool> HasKeyAsync(string key);
    Task<TCache> Get<TCache>(string key);
}
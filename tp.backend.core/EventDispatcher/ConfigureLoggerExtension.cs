using Microsoft.Extensions.DependencyInjection;

namespace tp.backend.core.EventDispatcher;

public static class ConfigureEventDispatcherExtension
{
    public static void AddEventDispatcher(this IServiceCollection services)
    {
        services.AddSingleton<IEventDispatcher, EventDispatcher>();
    }
}
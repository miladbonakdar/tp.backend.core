using Microsoft.Extensions.DependencyInjection;

namespace tp.backend.core.EventDispatcher
{
    class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _provider;

        public EventDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent
        {
            var handlers = GetEventHandlers<TEvent>();
            foreach (var handler in handlers) await handler.Handle(@event);
        }

        private IEnumerable<IHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IApplicationEvent
        {
            var handlers = _provider.GetServices<IHandler<TEvent>>().ToList();
            return handlers;
        }
    }
}
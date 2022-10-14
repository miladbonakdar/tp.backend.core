
namespace tp.backend.core.EventDispatcher
{
    public interface IEventDispatcher
    {
        Task Raise<TEvent>(TEvent @event) where TEvent : IApplicationEvent;
    }
}

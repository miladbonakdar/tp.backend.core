namespace tp.backend.core.EventDispatcher
{
    public interface IHandler<in TEvent> where TEvent : IApplicationEvent
    {
        public Task Handle(TEvent @event);
    }
}
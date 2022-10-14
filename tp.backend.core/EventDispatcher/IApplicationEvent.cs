namespace tp.backend.core.EventDispatcher;

public interface IApplicationEvent
{
    DateTime OccurredAt { get; }
}
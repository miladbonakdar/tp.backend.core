namespace tp.backend.core.EventDispatcher;

public abstract class BaseApplicationEvent
{
    protected BaseApplicationEvent()
    {
        OccurredAt = DateTimeOffset.Now;
    }
    DateTimeOffset OccurredAt { get; }
}
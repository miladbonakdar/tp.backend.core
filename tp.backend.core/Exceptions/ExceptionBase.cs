namespace tp.backend.core.Exceptions;

public abstract class ExceptionBase : Exception
{
    protected ExceptionBase(string message) : base(message)
    {
        Time = DateTimeOffset.Now;
    }

    public DateTimeOffset Time { get; }
}
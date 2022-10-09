namespace tp.backend.core.Exceptions;

public class NotFoundException : ExceptionBase
{
    public NotFoundException(string id = default, string message = "cannot be found") : base(message)
    {
        Id = id;
    }

    public string Id { get; }
}
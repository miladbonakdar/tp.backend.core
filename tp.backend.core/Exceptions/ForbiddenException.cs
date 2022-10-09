namespace tp.backend.core.Exceptions;

public class ForbiddenException : ExceptionBase
{
    public ForbiddenException(string message = "dont have access") : base(message)
    {
    }
}
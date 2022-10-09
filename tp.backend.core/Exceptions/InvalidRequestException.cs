namespace tp.backend.core.Exceptions;

public class InvalidRequestException : ExceptionBase
{
    public InvalidRequestException(string message = "invalid params") : base(message)
    {
    }
}
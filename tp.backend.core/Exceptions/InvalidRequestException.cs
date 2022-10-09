using tp.shared.Exceptions;

namespace SharedKernel.Exceptions;

public class InvalidRequestException : ExceptionBase
{
    public InvalidRequestException(string message = "invalid params") : base(message)
    {
    }
}
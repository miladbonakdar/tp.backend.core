namespace tp.shared.Exceptions;

public class BadRequestException : ExceptionBase
{
    public BadRequestException(string key = default, string message = "invalid params") : base(message)
    {
        Key = key;
    }

    public string Key { get; }
}
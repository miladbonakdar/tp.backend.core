using System.Text.Json;

namespace tp.shared;

public class ExceptionResult
{
    public ExceptionResult(string message, int statusCode, string? trace)
    {
        Message = message;
        StatusCode = statusCode;
        Trace = trace;
    }

    public string Message { get; }
    public int StatusCode { get; }
    public string? Trace { get; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
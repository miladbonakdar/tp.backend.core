namespace tp.shared.OTP;

public class OtpOptions
{
    public string TokenPrefix { get; init; } = "";
    public int Duration { get; init; }
    public int Digits { get; init; }
}
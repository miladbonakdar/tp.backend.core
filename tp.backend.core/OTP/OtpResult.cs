namespace tp.backend.core.OTP;

public enum OtpType
{
    Register,
    Login,
    Validate,
    CustomAction
}

public class OtpResult
{
    public int Duration { get; set; }
    public string OtpToken { get; set; }
    public OtpType Type { get; set; }
}
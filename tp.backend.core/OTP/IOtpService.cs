namespace tp.backend.core.OTP;

public interface IOtpService
{
    Task<OtpResult> Generate(string key, OtpType type);
    Task<bool> Validate(string key, OtpType type, string otpToken);
}
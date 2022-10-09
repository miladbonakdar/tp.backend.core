using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace tp.backend.core.OTP;

public static class ConfigureOtpExtension
{
    public static void AddOtpModule(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<OtpOptions>(configuration.GetSection("OTP"));
        services.AddSingleton<IOtpService, OtpService>();
    }
}
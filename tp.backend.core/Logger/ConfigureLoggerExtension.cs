using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace tp.shared.Logger;

public static class ConfigureLoggerExtension
{
    public static void CreateAndAddLogger(this IServiceCollection services)
    {
        var logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Logger = logger;
        services.AddSingleton<ILogger>(logger);
    }
}
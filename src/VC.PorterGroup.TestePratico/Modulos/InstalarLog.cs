using Serilog;

namespace VC.PorterGroup.TestePratico;

public static class InstaladorConfig
{
    public static IServiceCollection ConfigurarLog(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(config);

        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

        services.AddLogging(logBuilder =>
        {
            logBuilder.ClearProviders();
            logBuilder.AddSerilog(dispose: true);
        });

        return services;
    }
}
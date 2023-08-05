using Microsoft.Extensions.Logging;

namespace VC.PorterGroup.TestePratico.Infra.Core.Util.Mock;

public class LoggerMock<T> : ILogger<T>
{
    public LoggerMock()
    {
        Logs = new List<string>();
    }

    public List<string> Logs { get; }

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        var logMessage = formatter(state, exception);
        Logs.Add(logMessage);
    }
}
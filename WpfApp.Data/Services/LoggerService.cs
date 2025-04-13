using System;
using WpfApp.Core.Services;

namespace WpfApp.Data.Services;

public class LoggerService : ILoggerService
{
    private readonly ILoggingStrategy _loggingStrategy;

    public LoggerService(ILoggingStrategy loggingStrategy)
    {
        _loggingStrategy = loggingStrategy;
    }

    public void LogInfo(string message)
    {
        _loggingStrategy.Log($"INFO: {message}");
    }

    public void LogError(string message)
    {
        _loggingStrategy.Log($"ERROR: {message}");
    }

    public void LogWarning(string message)
    {
        _loggingStrategy.Log($"WARNING: {message}");
    }
}

using System;

namespace WpfApp.Core.Services
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}

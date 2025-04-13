using System.Diagnostics;
using WpfApp.Core.Services;

namespace WpfApp.Data.Services;

public class ConsoleLoggingStrategy : ILoggingStrategy
{
    public void Log(string message)
    {
        Debug.WriteLine($"CONSOLE: {message}");
    }
}

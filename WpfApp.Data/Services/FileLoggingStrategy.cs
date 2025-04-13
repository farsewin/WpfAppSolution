using System.IO;
using WpfApp.Core.Services;

namespace WpfApp.Data.Services;

public class FileLoggingStrategy : ILoggingStrategy
{
    private readonly string _filePath;

    public FileLoggingStrategy(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_filePath, $"{message}{Environment.NewLine}");
    }
}

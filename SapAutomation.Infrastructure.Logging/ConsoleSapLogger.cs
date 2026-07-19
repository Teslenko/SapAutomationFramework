using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Logging;

/// <summary>
/// Простая реализация <see cref="ISapLogger"/>, пишущая структурированные записи в консоль.
/// </summary>
public sealed class ConsoleSapLogger : ISapLogger
{
    public void Debug(string message) => Write("DEBUG", message);

    public void Info(string message) => Write("INFO", message);

    public void Warning(string message) => Write("WARN", message);

    public void Error(string message, Exception? exception = null) =>
        Write("ERROR", exception is null ? message : $"{message} | Exception: {exception.Message}");

    private static void Write(string level, string message) =>
        Console.WriteLine($"[{level}] {message}");
}

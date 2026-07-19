namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Логгер-заглушка (Null Object), ничего не делающий. Используется по умолчанию,
/// когда вызывающая сторона не передала реальный <see cref="ISapLogger"/>.
/// </summary>
public sealed class NullSapLogger : ISapLogger
{
    public static readonly NullSapLogger Instance = new();

    private NullSapLogger()
    {
    }

    public void Debug(string message)
    {
    }

    public void Info(string message)
    {
    }

    public void Warning(string message)
    {
    }

    public void Error(string message, Exception? exception = null)
    {
    }
}

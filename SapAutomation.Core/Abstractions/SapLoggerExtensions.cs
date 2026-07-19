namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Вспомогательные методы форматированного логирования действий над элементами SAP GUI.
/// </summary>
public static class SapLoggerExtensions
{
    /// <summary>
    /// Логирует действие над элементом SAP GUI в едином структурированном формате:
    /// <c>Action: {action} | ElementId: {elementId} | Duration: {duration} ms | Result: {result}</c>.
    /// </summary>
    public static void LogAction(this ISapLogger logger, string action, string elementId, TimeSpan duration, string result)
    {
        logger.Info(
            $"Action: {action} | ElementId: {elementId} | Duration: {duration.TotalMilliseconds:F0} ms | Result: {result}");
    }
}

namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Минимальный интерфейс логирования фреймворка, не привязанный к конкретной библиотеке логирования.
/// </summary>
public interface ISapLogger
{
    /// <summary>
    /// Отладочное сообщение (детали выполнения, не предназначенные для обычного мониторинга).
    /// </summary>
    void Debug(string message);

    /// <summary>
    /// Информационное сообщение о штатном ходе выполнения (например, действие над элементом SAP GUI).
    /// </summary>
    void Info(string message);

    /// <summary>
    /// Предупреждение о ситуации, которая не является ошибкой, но заслуживает внимания.
    /// </summary>
    void Warning(string message);

    /// <summary>
    /// Сообщение об ошибке, опционально с исключением, вызвавшим её.
    /// </summary>
    void Error(string message, Exception? exception = null);
}

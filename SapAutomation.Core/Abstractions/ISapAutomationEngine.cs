using SapAutomation.Core.Models;

namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Точка входа фреймворка автоматизации SAP GUI: устанавливает соединение с системой SAP.
/// </summary>
public interface ISapAutomationEngine
{
    /// <summary>
    /// Устанавливает соединение с системой SAP по указанным параметрам подключения.
    /// </summary>
    /// <param name="options">Параметры соединения (идентификатор системы, учётные данные, мандант, таймаут).</param>
    /// <returns>Установленное соединение с системой SAP.</returns>
    ISapConnection Connect(ConnectionOptions options);
}

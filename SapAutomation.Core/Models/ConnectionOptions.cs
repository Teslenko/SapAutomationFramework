namespace SapAutomation.Core.Models;

/// <summary>
/// Параметры, необходимые для установления соединения с системой SAP.
/// </summary>
public sealed class ConnectionOptions
{
    /// <summary>
    /// Идентификатор соединения (например, системный ID SAP).
    /// </summary>
    public required string ConnectionId { get; init; }

    /// <summary>
    /// Имя пользователя для входа в систему SAP.
    /// </summary>
    public string? User { get; init; }

    /// <summary>
    /// Пароль пользователя для входа в систему SAP.
    /// </summary>
    public string? Password { get; init; }

    /// <summary>
    /// Мандант (client) SAP, в который выполняется вход.
    /// </summary>
    public string? Client { get; init; }

    /// <summary>
    /// Таймаут ожидания установления соединения. По умолчанию — 30 секунд.
    /// </summary>
    public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(30);
}

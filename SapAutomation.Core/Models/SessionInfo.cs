namespace SapAutomation.Core.Models;

/// <summary>
/// Информация о текущем состоянии сессии SAP GUI.
/// </summary>
public sealed class SessionInfo
{
    /// <summary>
    /// Идентификатор сессии SAP GUI.
    /// </summary>
    public required string SessionId { get; init; }

    /// <summary>
    /// Код текущей транзакции, открытой в сессии (если есть).
    /// </summary>
    public string? TransactionCode { get; init; }

    /// <summary>
    /// Признак того, что сессия занята выполнением операции и недоступна для новых команд.
    /// </summary>
    public bool IsBusy { get; init; }
}

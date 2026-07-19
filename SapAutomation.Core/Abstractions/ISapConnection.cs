namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Активное соединение с системой SAP, через которое можно открывать сессии SAP GUI.
/// </summary>
public interface ISapConnection
{
    /// <summary>
    /// Идентификатор текущего соединения.
    /// </summary>
    string ConnectionId { get; }

    /// <summary>
    /// Признак того, что соединение установлено и активно.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Открывает новую сессию SAP GUI в рамках данного соединения.
    /// </summary>
    /// <returns>Открытая сессия SAP GUI.</returns>
    ISapSession OpenSession();

    /// <summary>
    /// Закрывает соединение с системой SAP.
    /// </summary>
    void Close();
}

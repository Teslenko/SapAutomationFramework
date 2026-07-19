using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация соединения с SAP. Открывает одну и ту же mock-сессию,
/// заранее подготовленную вызывающей стороной (например, тестом).
/// </summary>
public class MockSapConnection : ISapConnection
{
    private readonly MockSapSession _session;

    public MockSapConnection(string connectionId, MockSapSession session)
    {
        ConnectionId = connectionId;
        _session = session;
        IsConnected = true;
    }

    public string ConnectionId { get; }

    public bool IsConnected { get; private set; }

    public ISapSession OpenSession() => _session;

    public void Close() => IsConnected = false;
}

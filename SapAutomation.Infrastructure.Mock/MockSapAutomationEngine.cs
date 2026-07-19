using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Models;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация движка автоматизации SAP для тестирования архитектуры Core
/// без реального SAP GUI и без COM-зависимостей.
/// </summary>
public class MockSapAutomationEngine : ISapAutomationEngine
{
    private readonly MockSapSession _session;

    public MockSapAutomationEngine(MockSapSession session)
    {
        _session = session;
    }

    public ISapConnection Connect(ConnectionOptions options) =>
        new MockSapConnection(options.ConnectionId, _session);
}

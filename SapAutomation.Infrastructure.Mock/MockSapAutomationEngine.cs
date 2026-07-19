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
    private readonly ISapLogger _logger;

    public MockSapAutomationEngine(MockSapSession session, ISapLogger? logger = null)
    {
        _session = session;
        _logger = logger ?? NullSapLogger.Instance;
    }

    public ISapConnection Connect(ConnectionOptions options)
    {
        _logger.Info($"Connect | {options.ToLogSafeString()}");
        return new MockSapConnection(options.ConnectionId, _session);
    }
}

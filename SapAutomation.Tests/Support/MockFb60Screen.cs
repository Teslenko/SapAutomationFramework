using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Models;
using SapAutomation.Infrastructure.Mock;
using SapAutomation.Tests.Pages;

namespace SapAutomation.Tests.Support;

/// <summary>
/// Собирает mock-сессию экрана FB60 с элементами, зарегистрированными по тем же id,
/// что использует <see cref="Fb60Page"/>. Позволяет тестам конфигурировать поведение мока,
/// не обращаясь к локаторам напрямую.
/// </summary>
internal static class MockFb60Screen
{
    public static ISapSession Create(string statusBarTextAfterSave, ISapLogger? logger = null)
    {
        var statusBar = new MockSapStatusBar(Fb60Page.StatusBarId);
        var vendor = new MockSapTextBox(Fb60Page.VendorFieldId, logger: logger);
        var amount = new MockSapTextBox(Fb60Page.AmountFieldId, logger: logger);
        var save = new MockSapButton(
            Fb60Page.SaveButtonId,
            onClick: () => statusBar.SetText(statusBarTextAfterSave),
            logger: logger);

        var session = new MockSapSession("fb60-mock-session");
        session.Register(vendor);
        session.Register(amount);
        session.Register(save);
        session.Register(statusBar);

        var engine = new MockSapAutomationEngine(session, logger);
        var connection = engine.Connect(new ConnectionOptions { ConnectionId = "T01" });

        return connection.OpenSession();
    }
}

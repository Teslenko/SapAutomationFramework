using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Exceptions;
using SapAutomation.Core.Models;
using SapAutomation.Infrastructure.Mock;

namespace SapAutomation.Tests.Scenarios;

public class MockDriverScenarioTests
{
    private static ISapSession OpenMockTransaction(MockSapSession session)
    {
        var engine = new MockSapAutomationEngine(session);
        var connection = engine.Connect(new ConnectionOptions { ConnectionId = "T01" });
        return connection.OpenSession();
    }

    [Test]
    public void EnterValue_ClickSave_StatusBarConfirmsSuccess()
    {
        var statusBar = new MockSapStatusBar("wnd[0]/sbar");
        var userNameField = new MockSapTextBox("wnd[0]/usr/txtUserName");
        var saveButton = new MockSapButton(
            "wnd[0]/tbar[0]/btn[11]",
            onClick: () => statusBar.SetText($"Данные для '{userNameField.GetValue()}' сохранены"));

        var session = new MockSapSession("session-1");
        session.Register(userNameField);
        session.Register(saveButton);
        session.Register(statusBar);

        var sapSession = OpenMockTransaction(session);

        var textBox = (ISapTextBox)sapSession.FindElementById("wnd[0]/usr/txtUserName");
        var button = (ISapButton)sapSession.FindElementById("wnd[0]/tbar[0]/btn[11]");
        var bar = (ISapStatusBar)sapSession.FindElementById("wnd[0]/sbar");

        textBox.SetValue("ivanov");
        button.Click();

        Assert.That(bar.GetText(), Is.EqualTo("Данные для 'ivanov' сохранены"));
        Assert.DoesNotThrow(() => bar.ShouldContain("сохранены"));
    }

    [Test]
    public void ShouldContain_ThrowsSapAutomationException_WhenTextIsMissing()
    {
        var statusBar = new MockSapStatusBar("wnd[0]/sbar", text: "Введите обязательное поле");

        var session = new MockSapSession("session-2");
        session.Register(statusBar);

        var sapSession = OpenMockTransaction(session);
        var bar = (ISapStatusBar)sapSession.FindElementById("wnd[0]/sbar");

        Assert.Throws<SapAutomationException>(() => bar.ShouldContain("сохранены"));
    }
}

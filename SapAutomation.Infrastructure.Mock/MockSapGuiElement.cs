using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// Базовая in-memory реализация элемента SAP GUI для тестирования архитектуры Core без реального SAP.
/// </summary>
public class MockSapGuiElement : ISapGuiElement
{
    private readonly Action? _onClick;

    public MockSapGuiElement(string id, string text = "", Action? onClick = null)
    {
        Id = id;
        Text = text;
        _onClick = onClick;
    }

    public string Id { get; }

    public string Text { get; set; }

    public bool WasClicked { get; private set; }

    public void Click()
    {
        WasClicked = true;
        _onClick?.Invoke();
    }
}

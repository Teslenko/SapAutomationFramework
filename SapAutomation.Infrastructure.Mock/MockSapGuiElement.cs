using System.Diagnostics;
using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// Базовая in-memory реализация элемента SAP GUI для тестирования архитектуры Core без реального SAP.
/// </summary>
public class MockSapGuiElement : ISapGuiElement
{
    private readonly Action? _onClick;

    protected ISapLogger Logger { get; }

    public MockSapGuiElement(string id, string text = "", Action? onClick = null, ISapLogger? logger = null)
    {
        Id = id;
        Text = text;
        _onClick = onClick;
        Logger = logger ?? NullSapLogger.Instance;
    }

    public string Id { get; }

    public string Text { get; set; }

    public bool WasClicked { get; private set; }

    public void Click()
    {
        var stopwatch = Stopwatch.StartNew();

        WasClicked = true;
        _onClick?.Invoke();

        stopwatch.Stop();
        Logger.LogAction("Click", Id, stopwatch.Elapsed, "Success");
    }
}

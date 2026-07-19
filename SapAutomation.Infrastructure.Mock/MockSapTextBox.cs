using System.Diagnostics;
using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация текстового поля SAP GUI.
/// </summary>
public class MockSapTextBox : MockSapGuiElement, ISapTextBox
{
    public MockSapTextBox(string id, string text = "", ISapLogger? logger = null)
        : base(id, text, logger: logger)
    {
    }

    public void SetValue(string value)
    {
        var stopwatch = Stopwatch.StartNew();

        Text = value;

        stopwatch.Stop();
        Logger.LogAction("SetText", Id, stopwatch.Elapsed, "Success");
    }

    public string GetValue() => Text;
}

using System.Diagnostics;
using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация флажка (чекбокса) SAP GUI.
/// </summary>
public class MockSapCheckBox : MockSapGuiElement, ISapCheckBox
{
    public MockSapCheckBox(string id, bool isChecked = false, ISapLogger? logger = null)
        : base(id, text: string.Empty, logger: logger)
    {
        IsChecked = isChecked;
    }

    public bool IsChecked { get; private set; }

    public void Check() => SetChecked(true, "Check");

    public void Uncheck() => SetChecked(false, "Uncheck");

    private void SetChecked(bool value, string action)
    {
        var stopwatch = Stopwatch.StartNew();

        IsChecked = value;

        stopwatch.Stop();
        Logger.LogAction(action, Id, stopwatch.Elapsed, "Success");
    }
}

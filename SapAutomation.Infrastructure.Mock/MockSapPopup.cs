using System.Diagnostics;
using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация стандартного диалога SAP GUI (например, "Save changes?").
/// </summary>
public class MockSapPopup : MockSapGuiElement, ISapPopup
{
    private readonly Action? _onConfirm;
    private readonly Action? _onCancel;

    public MockSapPopup(string id, string text, Action? onConfirm = null, Action? onCancel = null, ISapLogger? logger = null)
        : base(id, text, logger: logger)
    {
        _onConfirm = onConfirm;
        _onCancel = onCancel;
    }

    public string GetText() => Text;

    public void Confirm()
    {
        var stopwatch = Stopwatch.StartNew();

        _onConfirm?.Invoke();

        stopwatch.Stop();
        Logger.LogAction("Confirm", Id, stopwatch.Elapsed, "Success");
    }

    public void Cancel()
    {
        var stopwatch = Stopwatch.StartNew();

        _onCancel?.Invoke();

        stopwatch.Stop();
        Logger.LogAction("Cancel", Id, stopwatch.Elapsed, "Success");
    }
}

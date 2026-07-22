using System.Diagnostics;
using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Exceptions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация выпадающего списка SAP GUI.
/// </summary>
public class MockSapComboBox : MockSapGuiElement, ISapComboBox
{
    private readonly List<string> _options;

    public MockSapComboBox(string id, IEnumerable<string> options, string? selectedValue = null, ISapLogger? logger = null)
        : base(id, text: selectedValue ?? "", logger: logger)
    {
        _options = options.ToList();
    }

    public void Select(string value)
    {
        var stopwatch = Stopwatch.StartNew();

        if (!_options.Contains(value))
        {
            throw new SapAutomationException(
                $"Значение '{value}' отсутствует в списке опций комбобокса '{Id}'. Доступные значения: {string.Join(", ", _options)}.");
        }

        Text = value;

        stopwatch.Stop();
        Logger.LogAction("Select", Id, stopwatch.Elapsed, "Success");
    }

    public string GetSelectedValue() => Text;

    public IReadOnlyList<string> GetOptions() => _options;
}

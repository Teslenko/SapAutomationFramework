using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация текстового поля SAP GUI.
/// </summary>
public class MockSapTextBox : MockSapGuiElement, ISapTextBox
{
    public MockSapTextBox(string id, string text = "")
        : base(id, text)
    {
    }

    public void SetValue(string value) => Text = value;

    public string GetValue() => Text;
}

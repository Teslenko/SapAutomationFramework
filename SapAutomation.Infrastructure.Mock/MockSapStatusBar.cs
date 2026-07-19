using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Exceptions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация строки статуса SAP GUI.
/// </summary>
public class MockSapStatusBar : MockSapGuiElement, ISapStatusBar
{
    public MockSapStatusBar(string id, string text = "")
        : base(id, text)
    {
    }

    /// <summary>
    /// Устанавливает текст строки статуса. Используется в моках для имитации реакции системы на действия пользователя.
    /// </summary>
    public void SetText(string text) => Text = text;

    public string GetText() => Text;

    public void ShouldContain(string expectedText)
    {
        if (!Text.Contains(expectedText, StringComparison.Ordinal))
        {
            throw new SapAutomationException(
                $"Строка статуса '{Text}' не содержит ожидаемый текст '{expectedText}'.");
        }
    }
}

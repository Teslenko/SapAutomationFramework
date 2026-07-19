using SapAutomation.Core.Abstractions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация кнопки SAP GUI. Клик может вызывать переданный делегат,
/// чтобы имитировать реакцию системы (например, обновление строки статуса).
/// </summary>
public class MockSapButton : MockSapGuiElement, ISapButton
{
    public MockSapButton(string id, Action? onClick = null)
        : base(id, text: string.Empty, onClick: onClick)
    {
    }
}

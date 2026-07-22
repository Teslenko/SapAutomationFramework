namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Стандартный диалог SAP GUI (например, "Save changes?").
/// </summary>
public interface ISapPopup : ISapGuiElement
{
    /// <summary>
    /// Возвращает текст сообщения диалога.
    /// </summary>
    string GetText();

    /// <summary>
    /// Подтверждает диалог (например, "Yes"/"Save").
    /// </summary>
    void Confirm();

    /// <summary>
    /// Отменяет диалог (например, "No"/"Cancel").
    /// </summary>
    void Cancel();
}

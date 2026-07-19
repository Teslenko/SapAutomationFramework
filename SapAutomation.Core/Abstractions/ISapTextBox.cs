namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Поле ввода текста в интерфейсе SAP GUI.
/// </summary>
public interface ISapTextBox : ISapGuiElement
{
    /// <summary>
    /// Устанавливает значение поля ввода.
    /// </summary>
    /// <param name="value">Значение, которое нужно ввести в поле.</param>
    void SetValue(string value);

    /// <summary>
    /// Возвращает текущее значение поля ввода.
    /// </summary>
    string GetValue();
}

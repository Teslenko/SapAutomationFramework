namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Выпадающий список (комбобокс) в интерфейсе SAP GUI.
/// </summary>
public interface ISapComboBox : ISapGuiElement
{
    /// <summary>
    /// Выбирает значение из списка опций.
    /// </summary>
    /// <param name="value">Значение, которое нужно выбрать.</param>
    /// <exception cref="Exceptions.SapAutomationException">Значение отсутствует в списке опций.</exception>
    void Select(string value);

    /// <summary>
    /// Возвращает текущее выбранное значение.
    /// </summary>
    string GetSelectedValue();

    /// <summary>
    /// Возвращает список доступных для выбора значений.
    /// </summary>
    IReadOnlyList<string> GetOptions();
}

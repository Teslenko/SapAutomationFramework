namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Элемент интерфейса SAP GUI (поле, кнопка, ссылка и т.п.), с которым можно взаимодействовать.
/// </summary>
public interface ISapGuiElement
{
    /// <summary>
    /// Идентификатор элемента в дереве компонентов SAP GUI.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Текстовое значение элемента (например, содержимое поля ввода).
    /// </summary>
    string Text { get; set; }

    /// <summary>
    /// Выполняет клик по элементу.
    /// </summary>
    void Click();
}

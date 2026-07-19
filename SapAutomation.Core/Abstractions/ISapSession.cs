namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Сессия SAP GUI, в рамках которой выполняется поиск и взаимодействие с элементами интерфейса.
/// </summary>
public interface ISapSession
{
    /// <summary>
    /// Идентификатор данной сессии SAP GUI.
    /// </summary>
    string SessionId { get; }

    /// <summary>
    /// Находит элемент интерфейса SAP GUI по его идентификатору (id элемента дерева GuiComponent).
    /// </summary>
    /// <param name="id">Идентификатор искомого элемента.</param>
    /// <returns>Найденный элемент интерфейса SAP GUI.</returns>
    ISapGuiElement FindElementById(string id);
}

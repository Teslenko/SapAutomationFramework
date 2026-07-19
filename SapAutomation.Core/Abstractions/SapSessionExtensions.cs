using SapAutomation.Core.Exceptions;

namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Вспомогательные типобезопасные методы поиска элементов SAP GUI поверх <see cref="ISapSession"/>.
/// </summary>
public static class SapSessionExtensions
{
    /// <summary>
    /// Находит элемент по id и приводит его к ожидаемому типу (например, <see cref="ISapTextBox"/>).
    /// </summary>
    /// <typeparam name="T">Ожидаемый тип элемента SAP GUI.</typeparam>
    /// <param name="session">Сессия, в которой выполняется поиск.</param>
    /// <param name="id">Идентификатор искомого элемента.</param>
    /// <returns>Найденный элемент, приведённый к типу <typeparamref name="T"/>.</returns>
    /// <exception cref="SapAutomationException">Элемент найден, но имеет другой тип.</exception>
    public static T FindElementById<T>(this ISapSession session, string id)
        where T : class, ISapGuiElement
    {
        var element = session.FindElementById(id);

        if (element is not T typed)
        {
            throw new SapAutomationException(
                $"Элемент с id '{id}' найден, но имеет тип '{element.GetType().Name}', а не ожидаемый '{typeof(T).Name}'.");
        }

        return typed;
    }
}

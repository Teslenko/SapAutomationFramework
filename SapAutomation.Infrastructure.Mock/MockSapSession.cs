using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Exceptions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация сессии SAP GUI. Элементы регистрируются заранее (например, тестом)
/// и находятся по id без обращения к реальному SAP GUI.
/// </summary>
public class MockSapSession : ISapSession
{
    private readonly Dictionary<string, ISapGuiElement> _elements = new();

    public MockSapSession(string sessionId)
    {
        SessionId = sessionId;
    }

    public string SessionId { get; }

    /// <summary>
    /// Регистрирует элемент в сессии, чтобы его можно было найти через <see cref="FindElementById"/>.
    /// </summary>
    public void Register(ISapGuiElement element) => _elements[element.Id] = element;

    public ISapGuiElement FindElementById(string id)
    {
        if (!_elements.TryGetValue(id, out var element))
        {
            throw new SapAutomationException($"Элемент с id '{id}' не найден в mock-сессии '{SessionId}'.");
        }

        return element;
    }
}

namespace SapAutomation.Core.Abstractions;

public interface ISapSession
{
    string SessionId { get; }

    ISapGuiElement FindElementById(string id);
}

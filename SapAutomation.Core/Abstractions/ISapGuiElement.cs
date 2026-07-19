namespace SapAutomation.Core.Abstractions;

public interface ISapGuiElement
{
    string Id { get; }

    string Text { get; set; }

    void Click();
}

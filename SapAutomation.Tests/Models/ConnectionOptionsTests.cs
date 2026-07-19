using SapAutomation.Core.Models;

namespace SapAutomation.Tests.Models;

public class ConnectionOptionsTests
{
    [Test]
    public void Constructor_SetsAllProperties()
    {
        var options = new ConnectionOptions("PRD", "100", "EN");

        Assert.That(options.SystemId, Is.EqualTo("PRD"));
        Assert.That(options.Client, Is.EqualTo("100"));
        Assert.That(options.Language, Is.EqualTo("EN"));
    }

    [Test]
    public void Equality_IsValueBased()
    {
        var first = new ConnectionOptions("PRD", "100", "EN");
        var second = new ConnectionOptions("PRD", "100", "EN");

        Assert.That(first, Is.EqualTo(second));
    }
}

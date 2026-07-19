using SapAutomation.Core.Models;

namespace SapAutomation.Tests.Models;

public class ConnectionOptionsTests
{
    [Test]
    public void Constructor_SetsAllProperties()
    {
        var options = new ConnectionOptions
        {
            ConnectionId = "PRD",
            User = "user1",
            Password = "secret",
            Client = "100",
            Timeout = TimeSpan.FromSeconds(60),
        };

        Assert.That(options.ConnectionId, Is.EqualTo("PRD"));
        Assert.That(options.User, Is.EqualTo("user1"));
        Assert.That(options.Password, Is.EqualTo("secret"));
        Assert.That(options.Client, Is.EqualTo("100"));
        Assert.That(options.Timeout, Is.EqualTo(TimeSpan.FromSeconds(60)));
    }

    [Test]
    public void Timeout_DefaultsToThirtySeconds()
    {
        var options = new ConnectionOptions { ConnectionId = "PRD" };

        Assert.That(options.Timeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
    }
}

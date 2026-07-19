using SapAutomation.Core.Exceptions;

namespace SapAutomation.Tests.Exceptions;

public class SapAutomationExceptionTests
{
    [Test]
    public void Constructor_WithMessage_SetsMessage()
    {
        var exception = new SapAutomationException("connection failed");

        Assert.That(exception.Message, Is.EqualTo("connection failed"));
    }

    [Test]
    public void Constructor_WithInnerException_SetsInnerException()
    {
        var inner = new InvalidOperationException("com error");

        var exception = new SapAutomationException("connection failed", inner);

        Assert.That(exception.InnerException, Is.SameAs(inner));
    }
}

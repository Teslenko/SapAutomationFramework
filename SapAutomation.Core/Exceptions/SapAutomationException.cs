namespace SapAutomation.Core.Exceptions;

public class SapAutomationException : Exception
{
    public SapAutomationException(string message)
        : base(message)
    {
    }

    public SapAutomationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

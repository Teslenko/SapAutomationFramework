namespace SapAutomation.Core.Abstractions;

public interface ISapConnection
{
    string ConnectionId { get; }

    bool IsConnected { get; }

    ISapSession OpenSession();

    void Close();
}

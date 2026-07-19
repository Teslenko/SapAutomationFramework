using SapAutomation.Core.Models;

namespace SapAutomation.Core.Abstractions;

public interface ISapAutomationEngine
{
    ISapConnection Connect(ConnectionOptions options);
}

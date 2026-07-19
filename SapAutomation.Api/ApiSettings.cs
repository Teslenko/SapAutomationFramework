using System.Text.Json.Serialization;

namespace SapAutomation.Api;

/// <summary>
/// Минимальные настройки API-модуля. Не зависит от SapAutomationSettings ядра фреймворка,
/// чтобы модуль оставался независимым от Core Framework/SAP GUI слоя.
/// </summary>
public sealed class ApiSettings
{
    public string? ApiBaseUrl { get; init; }

    public int TimeoutSeconds { get; init; } = 30;

    public bool VerboseLogging { get; init; }

    [JsonIgnore]
    public TimeSpan Timeout => TimeSpan.FromSeconds(TimeoutSeconds);
}

using System.Text.Json;

namespace SapAutomation.Tests.Fixtures;

/// <summary>
/// Минимальная модель ответа httpbin.org (/get, /post и т.п.) — сервис эхом
/// возвращает URL запроса и присланное JSON-тело.
/// </summary>
public sealed class HttpBinResponse
{
    public string? Url { get; init; }

    public JsonElement? Json { get; init; }
}

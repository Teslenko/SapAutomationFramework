using System.Net;

namespace SapAutomation.Api;

/// <summary>
/// Результат вызова API: код статуса, десериализованное тело (если удалось),
/// сырой контент (на случай не-JSON ответа) и длительность запроса.
/// </summary>
public sealed class ApiResponse<T>
{
    public required HttpStatusCode StatusCode { get; init; }

    public T? Body { get; init; }

    public required bool IsSuccess { get; init; }

    public required string RawContent { get; init; }

    public required TimeSpan Duration { get; init; }
}

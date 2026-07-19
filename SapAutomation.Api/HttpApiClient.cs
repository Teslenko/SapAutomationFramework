using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using SapAutomation.Api.Auth;
using SapAutomation.Core.Abstractions;

namespace SapAutomation.Api;

/// <summary>
/// Реализация <see cref="IApiClient"/> поверх переданного извне <see cref="HttpClient"/>
/// (совместимо с IHttpClientFactory — клиент сам сокеты не открывает и не хранит).
/// </summary>
public sealed class HttpApiClient : IApiClient
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    private readonly HttpClient _httpClient;
    private readonly IAuthProvider? _authProvider;
    private readonly ISapLogger _logger;
    private readonly bool _verboseLogging;

    public HttpApiClient(
        HttpClient httpClient,
        IAuthProvider? authProvider = null,
        ISapLogger? logger = null,
        bool verboseLogging = false)
    {
        _httpClient = httpClient;
        _authProvider = authProvider;
        _logger = logger ?? NullSapLogger.Instance;
        _verboseLogging = verboseLogging;
    }

    public Task<ApiResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default) =>
        SendAsync<T>(HttpMethod.Get, requestUri, body: null, cancellationToken);

    public Task<ApiResponse<T>> PostAsync<T>(string requestUri, object? body = null, CancellationToken cancellationToken = default) =>
        SendAsync<T>(HttpMethod.Post, requestUri, body, cancellationToken);

    public Task<ApiResponse<T>> PutAsync<T>(string requestUri, object? body = null, CancellationToken cancellationToken = default) =>
        SendAsync<T>(HttpMethod.Put, requestUri, body, cancellationToken);

    public async Task<ApiResponse<string>> DeleteAsync(string requestUri, CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        using var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);

        if (_authProvider is not null)
        {
            await _authProvider.ApplyAsync(request, cancellationToken);
        }

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var rawContent = await response.Content.ReadAsStringAsync(cancellationToken);
        stopwatch.Stop();

        LogRequest(HttpMethod.Delete, requestUri, response.StatusCode, stopwatch.Elapsed, requestBody: null, rawContent);

        return new ApiResponse<string>
        {
            StatusCode = response.StatusCode,
            Body = rawContent,
            IsSuccess = response.IsSuccessStatusCode,
            RawContent = rawContent,
            Duration = stopwatch.Elapsed,
        };
    }

    private async Task<ApiResponse<T>> SendAsync<T>(
        HttpMethod method,
        string requestUri,
        object? body,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        using var request = new HttpRequestMessage(method, requestUri);

        if (body is not null)
        {
            var json = JsonSerializer.Serialize(body, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        if (_authProvider is not null)
        {
            await _authProvider.ApplyAsync(request, cancellationToken);
        }

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var rawContent = await response.Content.ReadAsStringAsync(cancellationToken);
        stopwatch.Stop();

        T? deserializedBody = default;
        if (rawContent.Length > 0)
        {
            try
            {
                deserializedBody = JsonSerializer.Deserialize<T>(rawContent, JsonOptions);
            }
            catch (JsonException)
            {
                // Ответ не является (валидным) JSON — вызывающая сторона может использовать RawContent.
            }
        }

        LogRequest(method, requestUri, response.StatusCode, stopwatch.Elapsed, body, rawContent);

        return new ApiResponse<T>
        {
            StatusCode = response.StatusCode,
            Body = deserializedBody,
            IsSuccess = response.IsSuccessStatusCode,
            RawContent = rawContent,
            Duration = stopwatch.Elapsed,
        };
    }

    private void LogRequest(
        HttpMethod method,
        string requestUri,
        HttpStatusCode statusCode,
        TimeSpan duration,
        object? requestBody,
        string rawContent)
    {
        _logger.Info(
            $"Method: {method} | Url: {requestUri} | StatusCode: {(int)statusCode} | Duration: {duration.TotalMilliseconds:F0} ms");

        if (_verboseLogging)
        {
            var requestBodyJson = requestBody is null ? "-" : JsonSerializer.Serialize(requestBody, JsonOptions);
            _logger.Debug($"Request body: {requestBodyJson} | Response body: {rawContent}");
        }
    }
}

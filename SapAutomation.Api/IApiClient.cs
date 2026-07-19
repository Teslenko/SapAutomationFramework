namespace SapAutomation.Api;

/// <summary>
/// Клиент для вызова REST/OData API, независимый от SAP GUI Scripting.
/// Используется как для тестирования API-сервисов напрямую, так и для подготовки/очистки
/// тестовых данных перед UI-сценариями.
/// </summary>
public interface IApiClient
{
    Task<ApiResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default);

    Task<ApiResponse<T>> PostAsync<T>(string requestUri, object? body = null, CancellationToken cancellationToken = default);

    Task<ApiResponse<T>> PutAsync<T>(string requestUri, object? body = null, CancellationToken cancellationToken = default);

    Task<ApiResponse<string>> DeleteAsync(string requestUri, CancellationToken cancellationToken = default);
}

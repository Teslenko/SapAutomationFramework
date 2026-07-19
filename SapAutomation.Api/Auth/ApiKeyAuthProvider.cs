namespace SapAutomation.Api.Auth;

/// <summary>
/// Авторизация через заголовок с API-ключом. Имя заголовка настраиваемое,
/// по умолчанию "X-API-Key".
/// </summary>
public sealed class ApiKeyAuthProvider : IAuthProvider
{
    private readonly string _apiKey;
    private readonly string _headerName;

    public ApiKeyAuthProvider(string apiKey, string headerName = "X-API-Key")
    {
        _apiKey = apiKey;
        _headerName = headerName;
    }

    public Task ApplyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        request.Headers.Remove(_headerName);
        request.Headers.TryAddWithoutValidation(_headerName, _apiKey);
        return Task.CompletedTask;
    }
}

using System.Net.Http.Headers;

namespace SapAutomation.Api.Auth;

/// <summary>
/// Авторизация через Bearer-токен (заголовок Authorization: Bearer {token}).
/// </summary>
public sealed class BearerTokenAuthProvider : IAuthProvider
{
    private readonly string _token;

    public BearerTokenAuthProvider(string token)
    {
        _token = token;
    }

    public Task ApplyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        return Task.CompletedTask;
    }
}

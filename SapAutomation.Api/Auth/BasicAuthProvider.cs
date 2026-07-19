using System.Net.Http.Headers;
using System.Text;

namespace SapAutomation.Api.Auth;

/// <summary>
/// Авторизация через HTTP Basic (заголовок Authorization: Basic {base64(user:password)}).
/// </summary>
public sealed class BasicAuthProvider : IAuthProvider
{
    private readonly string _userName;
    private readonly string _password;

    public BasicAuthProvider(string userName, string password)
    {
        _userName = userName;
        _password = password;
    }

    public Task ApplyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        var raw = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_userName}:{_password}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", raw);
        return Task.CompletedTask;
    }
}

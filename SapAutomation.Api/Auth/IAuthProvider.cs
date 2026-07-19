namespace SapAutomation.Api.Auth;

/// <summary>
/// Стратегия авторизации, применяемая к исходящему HTTP-запросу.
/// Подключается к <see cref="HttpApiClient"/> извне (конструктор/DI) — клиент не привязан
/// к конкретному способу авторизации.
/// </summary>
public interface IAuthProvider
{
    Task ApplyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}

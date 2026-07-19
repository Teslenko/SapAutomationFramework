using System.Net;
using SapAutomation.Api;
using SapAutomation.Tests.Fixtures;

namespace SapAutomation.Tests.Tests;

/// <summary>
/// Демонстрация IApiClient/HttpApiClient напрямую, независимо от SAP GUI Mock-слоя.
/// Использует httpbin.org как публичный эхо-сервис (не реальный SAP URL).
/// </summary>
public class ApiClientTests
{
    private static IApiClient CreateClient() =>
        new HttpApiClient(new HttpClient { BaseAddress = new Uri("https://httpbin.org") });

    [Test]
    public async Task GetAsync_ReturnsSuccessResponse_FromHttpBin()
    {
        var client = CreateClient();

        var response = await client.GetAsync<HttpBinResponse>("get");

        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Body?.Url, Does.Contain("httpbin.org/get"));
    }

    [Test]
    public async Task PostAsync_EchoesPostedBody_FromHttpBin()
    {
        var client = CreateClient();

        var response = await client.PostAsync<HttpBinResponse>("post", new { vendorId = "TEST-VENDOR-001" });

        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.RawContent, Does.Contain("TEST-VENDOR-001"));
    }
}

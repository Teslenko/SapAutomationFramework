using SapAutomation.Api;

namespace SapAutomation.Tests.Fixtures;

/// <summary>
/// Пример подготовки/очистки тестовых данных через API вокруг UI-сценария.
/// Использует httpbin.org как заглушечный эндпоинт (эхо-сервис) — реального SAP API
/// у проекта пока нет, см. docs/SAP_AUTOMATION_ROADMAP.md (Open Questions).
/// </summary>
public abstract class ApiTestDataFixture
{
    protected IApiClient ApiClient { get; private set; } = null!;

    protected string? CreatedVendorId { get; private set; }

    [SetUp]
    public async Task CreateTestVendor()
    {
        ApiClient = new HttpApiClient(new HttpClient { BaseAddress = new Uri("https://httpbin.org") });

        var response = await ApiClient.PostAsync<HttpBinResponse>(
            "post",
            new { vendorId = "TEST-VENDOR-001", name = "Test Vendor" });

        Assert.That(response.IsSuccess, Is.True, "Не удалось создать тестового вендора через API (precondition).");

        CreatedVendorId = "TEST-VENDOR-001";
    }

    [TearDown]
    public async Task DeleteTestVendor()
    {
        if (CreatedVendorId is null)
        {
            return;
        }

        await ApiClient.DeleteAsync($"delete?vendorId={CreatedVendorId}");
        CreatedVendorId = null;
    }
}

using SapAutomation.Tests.Fixtures;

namespace SapAutomation.Tests.Tests;

/// <summary>
/// Демонстрирует паттерн "создать данные через API -> выполнить UI-шаг -> удалить через API".
/// UI-шаг здесь — заглушка (плейсхолдер); в реальном сценарии на этом месте вызывался бы,
/// например, InvoiceFlow.PostVendorInvoice(CreatedVendorId, ...) на mock- или реальном SAP-драйвере.
/// </summary>
public class ApiVendorPreconditionScenarioTests : ApiTestDataFixture
{
    [Test]
    public void PostVendorInvoice_UsesVendorCreatedViaApi()
    {
        Assert.That(CreatedVendorId, Is.Not.Null, "Precondition (создание вендора через API) должен был выполниться в SetUp.");

        // [заглушка] UI-шаг: здесь должен быть вызов InvoiceFlow.PostVendorInvoice(CreatedVendorId, ...)
        var uiStepResult = $"UI step executed for vendor {CreatedVendorId}";

        Assert.That(uiStepResult, Does.Contain(CreatedVendorId!));
    }
}

using SapAutomation.Infrastructure.Logging;
using SapAutomation.Tests.Flows;
using SapAutomation.Tests.Pages;
using SapAutomation.Tests.Support;

namespace SapAutomation.Tests.Tests;

public class PostVendorInvoiceTests
{
    [Test]
    [Property("BusinessStep", "Post vendor invoice")]
    public void PostVendorInvoice_ReturnsConfirmationFromStatusBar()
    {
        var logger = new ConsoleSapLogger();
        var session = MockFb60Screen.Create(statusBarTextAfterSave: "Document posted", logger: logger);
        var invoiceFlow = new InvoiceFlow(session, logger);

        var result = invoiceFlow.PostVendorInvoice(vendorId: "100000", amount: 1500.00m);

        Assert.That(result, Is.EqualTo("Document posted"));
    }

    [Test]
    [Property("BusinessStep", "Post vendor invoice with explicit document type")]
    public void PostVendorInvoice_WithExplicitDocumentType_SelectsComboBoxValue()
    {
        var logger = new ConsoleSapLogger();
        var session = MockFb60Screen.Create(statusBarTextAfterSave: "Document posted", logger: logger);
        var invoiceFlow = new InvoiceFlow(session, logger);

        invoiceFlow.PostVendorInvoice(vendorId: "100000", amount: 1500.00m, documentType: "KG");

        Assert.That(new Fb60Page(session).DocumentType.GetSelectedValue(), Is.EqualTo("KG"));
    }
}

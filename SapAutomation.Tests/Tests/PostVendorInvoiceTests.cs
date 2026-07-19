using SapAutomation.Tests.Flows;
using SapAutomation.Tests.Support;

namespace SapAutomation.Tests.Tests;

public class PostVendorInvoiceTests
{
    [Test]
    public void PostVendorInvoice_ReturnsConfirmationFromStatusBar()
    {
        var session = MockFb60Screen.Create(statusBarTextAfterSave: "Document posted");
        var invoiceFlow = new InvoiceFlow(session);

        var result = invoiceFlow.PostVendorInvoice(vendorId: "100000", amount: 1500.00m);

        Assert.That(result, Is.EqualTo("Document posted"));
    }
}

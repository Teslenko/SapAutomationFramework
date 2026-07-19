using System.Diagnostics;
using System.Globalization;
using SapAutomation.Core.Abstractions;
using SapAutomation.Tests.Pages;

namespace SapAutomation.Tests.Flows;

/// <summary>
/// Business Flow проводки счёта поставщика через транзакцию FB60.
/// </summary>
public class InvoiceFlow
{
    private readonly ISapSession _session;
    private readonly ISapLogger _logger;

    public InvoiceFlow(ISapSession session, ISapLogger? logger = null)
    {
        _session = session;
        _logger = logger ?? NullSapLogger.Instance;
    }

    /// <summary>
    /// Проводит счёт поставщика и возвращает текст строки статуса после сохранения.
    /// </summary>
    public string PostVendorInvoice(string vendorId, decimal amount)
    {
        var stopwatch = Stopwatch.StartNew();
        var page = new Fb60Page(_session);

        page.Vendor.SetValue(vendorId);
        page.Amount.SetValue(amount.ToString(CultureInfo.InvariantCulture));
        page.Save.Click();

        var result = page.StatusBar.GetText();
        stopwatch.Stop();

        _logger.LogAction("Save", "InvoiceFlow.PostVendorInvoice", stopwatch.Elapsed, "Success");

        return result;
    }
}

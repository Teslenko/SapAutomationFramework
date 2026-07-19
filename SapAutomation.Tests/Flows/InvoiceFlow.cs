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

    public InvoiceFlow(ISapSession session)
    {
        _session = session;
    }

    /// <summary>
    /// Проводит счёт поставщика и возвращает текст строки статуса после сохранения.
    /// </summary>
    public string PostVendorInvoice(string vendorId, decimal amount)
    {
        var page = new Fb60Page(_session);

        page.Vendor.SetValue(vendorId);
        page.Amount.SetValue(amount.ToString(CultureInfo.InvariantCulture));
        page.Save.Click();

        return page.StatusBar.GetText();
    }
}

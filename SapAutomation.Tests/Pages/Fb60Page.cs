using SapAutomation.Core.Abstractions;

namespace SapAutomation.Tests.Pages;

/// <summary>
/// Page Object транзакции FB60 (ввод счёта поставщика). Инкапсулирует локаторы экрана
/// и предоставляет читаемый доступ к его полям.
/// </summary>
public class Fb60Page
{
    internal const string VendorFieldId = "wnd[0]/usr/ctxtBSEG-LIFNR";
    internal const string AmountFieldId = "wnd[0]/usr/txtBSEG-WRBTR";
    internal const string DocumentTypeComboBoxId = "wnd[0]/usr/cmbBKPF-BLART";
    internal const string SaveButtonId = "wnd[0]/tbar[0]/btn[11]";
    internal const string StatusBarId = "wnd[0]/sbar";

    private readonly ISapSession _session;

    public Fb60Page(ISapSession session)
    {
        _session = session;
    }

    public ISapTextBox Vendor => _session.FindElementById<ISapTextBox>(VendorFieldId);

    public ISapTextBox Amount => _session.FindElementById<ISapTextBox>(AmountFieldId);

    public ISapComboBox DocumentType => _session.FindElementById<ISapComboBox>(DocumentTypeComboBoxId);

    public ISapButton Save => _session.FindElementById<ISapButton>(SaveButtonId);

    public ISapStatusBar StatusBar => _session.FindElementById<ISapStatusBar>(StatusBarId);
}

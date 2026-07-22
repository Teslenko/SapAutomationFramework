using SapAutomation.Core.Exceptions;
using SapAutomation.Infrastructure.Mock;

namespace SapAutomation.Tests.Tests;

/// <summary>
/// Покрытие новых типов элементов SAP GUI на MockDriver: ComboBox, CheckBox, Table, Popup.
/// </summary>
public class NewSapElementsTests
{
    [Test]
    public void ComboBox_SelectsValue_AndRejectsValueNotInOptions()
    {
        var comboBox = new MockSapComboBox("cmbDocType", options: new[] { "RE", "KG" }, selectedValue: "RE");

        comboBox.Select("KG");

        Assert.That(comboBox.GetSelectedValue(), Is.EqualTo("KG"));
        Assert.That(comboBox.GetOptions(), Is.EquivalentTo(new[] { "RE", "KG" }));
        Assert.Throws<SapAutomationException>(() => comboBox.Select("ZZ"));
    }

    [Test]
    public void CheckBox_TracksCheckedState()
    {
        var checkBox = new MockSapCheckBox("chkPayImmediately");

        Assert.That(checkBox.IsChecked, Is.False);

        checkBox.Check();
        Assert.That(checkBox.IsChecked, Is.True);

        checkBox.Uncheck();
        Assert.That(checkBox.IsChecked, Is.False);
    }

    [Test]
    public void Table_FindRowByValue_LocatesRowByBusinessValue_NotByIndex()
    {
        var table = new MockSapTable("tblItems", new[]
        {
            new Dictionary<string, string> { ["VendorId"] = "100000", ["Amount"] = "500.00" },
            new Dictionary<string, string> { ["VendorId"] = "200000", ["Amount"] = "1500.00" },
        });

        var rowIndex = table.FindRowByValue("VendorId", "200000");

        Assert.That(rowIndex, Is.EqualTo(1));
        Assert.That(table.GetCellValue(rowIndex, "Amount"), Is.EqualTo("1500.00"));
        Assert.That(table.GetRowCount(), Is.EqualTo(2));
        Assert.Throws<SapAutomationException>(() => table.FindRowByValue("VendorId", "999999"));
    }

    [Test]
    public void Popup_ConfirmAndCancel_InvokeCallbacksAndExposeText()
    {
        var confirmed = false;
        var cancelled = false;

        var popup = new MockSapPopup(
            "wnd[1]",
            text: "Save changes?",
            onConfirm: () => confirmed = true,
            onCancel: () => cancelled = true);

        Assert.That(popup.GetText(), Is.EqualTo("Save changes?"));

        popup.Confirm();
        Assert.That(confirmed, Is.True);
        Assert.That(cancelled, Is.False);

        popup.Cancel();
        Assert.That(cancelled, Is.True);
    }
}

namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Флажок (чекбокс) в интерфейсе SAP GUI.
/// </summary>
public interface ISapCheckBox : ISapGuiElement
{
    /// <summary>
    /// Устанавливает флажок.
    /// </summary>
    void Check();

    /// <summary>
    /// Снимает флажок.
    /// </summary>
    void Uncheck();

    /// <summary>
    /// Текущее состояние флажка.
    /// </summary>
    bool IsChecked { get; }
}

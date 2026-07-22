namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Табличный контрол SAP GUI (GuiTableControl).
/// </summary>
public interface ISapTable : ISapGuiElement
{
    /// <summary>
    /// Возвращает значение ячейки по индексу строки и имени колонки.
    /// </summary>
    /// <exception cref="Exceptions.SapAutomationException">Строка или колонка не существуют.</exception>
    string GetCellValue(int row, string column);

    /// <summary>
    /// Возвращает количество строк в таблице.
    /// </summary>
    int GetRowCount();

    /// <summary>
    /// Находит индекс строки по бизнес-значению в указанной колонке — устойчиво к порядку
    /// строк и не зависит от жёстко заданного индекса.
    /// </summary>
    /// <param name="column">Имя колонки, по которой выполняется поиск.</param>
    /// <param name="value">Искомое значение.</param>
    /// <returns>Индекс найденной строки.</returns>
    /// <exception cref="Exceptions.SapAutomationException">Строка с таким значением не найдена.</exception>
    int FindRowByValue(string column, string value);
}

using SapAutomation.Core.Abstractions;
using SapAutomation.Core.Exceptions;

namespace SapAutomation.Infrastructure.Mock;

/// <summary>
/// In-memory реализация табличного контрола SAP GUI. Строки хранятся как словари
/// "имя колонки -> значение", что позволяет искать строки по бизнес-значению,
/// а не по жёсткому индексу.
/// </summary>
public class MockSapTable : MockSapGuiElement, ISapTable
{
    private readonly List<IReadOnlyDictionary<string, string>> _rows;

    public MockSapTable(string id, IEnumerable<IReadOnlyDictionary<string, string>> rows, ISapLogger? logger = null)
        : base(id, text: string.Empty, logger: logger)
    {
        _rows = rows.ToList();
    }

    public int GetRowCount() => _rows.Count;

    public string GetCellValue(int row, string column)
    {
        if (row < 0 || row >= _rows.Count)
        {
            throw new SapAutomationException(
                $"Таблица '{Id}': строка с индексом {row} не существует (всего строк: {_rows.Count}).");
        }

        if (!_rows[row].TryGetValue(column, out var value))
        {
            throw new SapAutomationException($"Таблица '{Id}': колонка '{column}' не найдена в строке {row}.");
        }

        return value;
    }

    public int FindRowByValue(string column, string value)
    {
        for (var i = 0; i < _rows.Count; i++)
        {
            if (_rows[i].TryGetValue(column, out var cellValue) && cellValue == value)
            {
                return i;
            }
        }

        throw new SapAutomationException($"Таблица '{Id}': строка с {column} = '{value}' не найдена.");
    }
}

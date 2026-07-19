namespace SapAutomation.Tests.Reporting;

/// <summary>
/// Одна запись отчёта о прогоне теста. Не содержит входных данных теста —
/// только метаданные о результате выполнения.
/// </summary>
public sealed record TestReportEntry(
    string TestName,
    string? BusinessStep,
    string Status,
    TimeSpan Duration,
    string? ErrorMessage);

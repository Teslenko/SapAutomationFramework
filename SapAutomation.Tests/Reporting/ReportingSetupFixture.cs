using SapAutomation.Tests.Reporting;

/// <summary>
/// Глобальный SetUpFixture (без namespace — действует на всю тестовую сборку).
/// После завершения всех тестов записывает собранный отчёт в TestResults/report.md.
/// </summary>
[SetUpFixture]
public class ReportingSetupFixture
{
    [OneTimeTearDown]
    public void WriteReport()
    {
        var path = TestReportCollector.WriteMarkdown(Path.Combine("TestResults", "report.md"));
        TestContext.Progress.WriteLine($"Test report written to: {path}");
    }
}

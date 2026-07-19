using System.Diagnostics;
using NUnit.Framework.Interfaces;

[assembly: SapAutomation.Tests.Reporting.ReportingTestAction]

namespace SapAutomation.Tests.Reporting;

/// <summary>
/// Глобальное действие NUnit, подключаемое ко всем тестам сборки через <c>[assembly: ...]</c>.
/// Замеряет длительность теста и после его завершения записывает результат в <see cref="TestReportCollector"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class ReportingTestAction : Attribute, ITestAction
{
    [ThreadStatic]
    private static Stopwatch? _stopwatch;

    public void BeforeTest(ITest test)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void AfterTest(ITest test)
    {
        _stopwatch?.Stop();
        var duration = _stopwatch?.Elapsed ?? TimeSpan.Zero;

        var result = TestContext.CurrentContext.Result;
        var businessStep = test.Properties.Get("BusinessStep") as string;

        TestReportCollector.Record(new TestReportEntry(
            TestName: test.FullName,
            BusinessStep: businessStep,
            Status: result.Outcome.Status.ToString(),
            Duration: duration,
            ErrorMessage: result.Outcome.Status == TestStatus.Failed ? result.Message : null));
    }

    public ActionTargets Targets => ActionTargets.Test;
}

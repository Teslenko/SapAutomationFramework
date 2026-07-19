using System.Collections.Concurrent;
using System.Text;

namespace SapAutomation.Tests.Reporting;

/// <summary>
/// Собирает результаты выполнения тестов и записывает их в простой Markdown-отчёт.
/// </summary>
public static class TestReportCollector
{
    private static readonly ConcurrentBag<TestReportEntry> Entries = new();

    public static void Record(TestReportEntry entry) => Entries.Add(entry);

    public static string WriteMarkdown(string relativePath)
    {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

        var builder = new StringBuilder();
        builder.AppendLine("# Test Report");
        builder.AppendLine();
        builder.AppendLine("| Test | Business Step | Status | Duration (ms) | Error |");
        builder.AppendLine("|---|---|---|---|---|");

        foreach (var entry in Entries.OrderBy(e => e.TestName))
        {
            var businessStep = entry.BusinessStep ?? "-";
            var error = entry.ErrorMessage?.Replace("|", "\\|").Replace("\n", " ") ?? "";

            builder.AppendLine(
                $"| {entry.TestName} | {businessStep} | {entry.Status} | {entry.Duration.TotalMilliseconds:F0} | {error} |");
        }

        File.WriteAllText(fullPath, builder.ToString());

        return fullPath;
    }
}

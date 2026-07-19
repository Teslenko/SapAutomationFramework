namespace SapAutomation.Core.Abstractions;

/// <summary>
/// Строка статуса SAP GUI, используемая для проверки результата операции.
/// </summary>
public interface ISapStatusBar : ISapGuiElement
{
    /// <summary>
    /// Возвращает текущий текст строки статуса.
    /// </summary>
    string GetText();

    /// <summary>
    /// Проверяет, что строка статуса содержит указанный текст.
    /// </summary>
    /// <param name="expectedText">Ожидаемый фрагмент текста.</param>
    /// <exception cref="Exceptions.SapAutomationException">Строка статуса не содержит ожидаемый текст.</exception>
    void ShouldContain(string expectedText);
}

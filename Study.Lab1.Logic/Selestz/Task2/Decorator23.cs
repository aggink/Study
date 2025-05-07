using Study.Lab1.Logic.Interfaces.Selestz.Task2;

namespace Study.Lab1.Logic.Selestz.Task2;

public class Decorator23 : IDateTimeFormatter
{
    private readonly IDateTimeFormatter _formatDate;

    public Decorator23(IDateTimeFormatter formatDate)
    {
        _formatDate = formatDate;
    }

    public string FormatDateTime()
    {
        return $"ALT + 23: ↨↨↨ {_formatDate.FormatDateTime()} ↨↨↨";
    }
}
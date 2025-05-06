using Study.Lab1.Logic.Interfaces.Selestz.Task2;

namespace Study.Lab1.Logic.Selestz.Task2;

public class PrefDecorator : IDateTimeFormatter
{
    private readonly IDateTimeFormatter _formatDate;

    public PrefDecorator(IDateTimeFormatter formatDate)
    {
        _formatDate = formatDate;
    }

    public string FormatDateTime()
    {
        return $"☺☺☺ {_formatDate.FormatDateTime()} ";
    }
}
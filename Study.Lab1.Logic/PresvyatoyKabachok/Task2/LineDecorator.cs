using Study.Lab1.Logic.Interfaces.PresvyatoyKabachok.Task2;

namespace Study.Lab1.Logic.PresvyatoyKabachok.Task2;

public class LineDecorator : IDateFormatter
{
    private readonly IDateFormatter _formatDate;

    public LineDecorator(IDateFormatter formatDate)
    {
        _formatDate = formatDate;
    }

    public string FormatDateTime()
    {
        return $"| {_formatDate.FormatDateTime()} |";
    }
}
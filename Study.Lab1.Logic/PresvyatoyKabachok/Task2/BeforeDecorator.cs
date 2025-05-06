using Study.Lab1.Logic.Interfaces.PresvyatoyKabachok.Task2;

namespace Study.Lab1.Logic.PresvyatoyKabachok.Task2;

public class BeforeDecorator : IDateFormatter
{
    private readonly IDateFormatter _formatDate;

    public BeforeDecorator(IDateFormatter formatDate)
    {
        _formatDate = formatDate;
    }

    public string FormatDateTime()
    {
        return $" `\\{_formatDate.FormatDateTime()}";
    }
}
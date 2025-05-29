using Study.Lab1.Logic.Interfaces.kinkiss1.task2;

namespace Study.Lab1.Logic.kinkiss1.Task2;

public class Decorator1 : IFormatDate
{
    private readonly IFormatDate _formatDate;

    public Decorator1(IFormatDate format)
    {
        _formatDate = format;
    }

    public string FormatDateTime()
    {
        return $"Date format: {_formatDate.FormatDateTime()}";
    }
}
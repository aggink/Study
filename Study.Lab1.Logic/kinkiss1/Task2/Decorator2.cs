using Study.Lab1.Logic.Interfaces.kinkiss1.task2;

namespace Study.Lab1.Logic.kinkiss1.Task2;

public class Decorator2 : IFormatDate
{
    private readonly IFormatDate _formatDate;

    public Decorator2(IFormatDate formatDate)
    {
        _formatDate = formatDate;
    }

    public string FormatDateTime()
    {
        return $"[Decorated] [{_formatDate.FormatDateTime()}]";
    }
}
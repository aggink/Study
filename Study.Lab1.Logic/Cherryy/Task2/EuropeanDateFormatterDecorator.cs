using Study.Lab1.Logic.Interfaces.Cherryy.Task2;

namespace Study.Lab1.Logic.Cherryy.Task2;

public class EuropeanDateFormatterDecorator : IFormatDate
{
    private EuropeanDateTimeFormatter _timeFormatter;

    public EuropeanDateFormatterDecorator(EuropeanDateTimeFormatter timeFormatter)
    {
        _timeFormatter = timeFormatter;
    }

    public string FormatDateTime(DateTime dateTime)
    {
        var text = _timeFormatter.FormatDateTime(dateTime);
        return $"European; {text}";
    }
}

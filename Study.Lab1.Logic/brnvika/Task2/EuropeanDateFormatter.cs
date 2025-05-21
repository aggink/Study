using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.brnvika.Task2;

public class EuropeanDateFormatter : IDateFormatter
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("d", new CultureInfo("ru-RU"));
    }

    public string FormatTime(DateTime time)
    {
        return time.ToString("T", new CultureInfo("ru-RU"));
    }
}

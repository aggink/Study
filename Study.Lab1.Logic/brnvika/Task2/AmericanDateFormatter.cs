using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.brnvika.Task2;

public class AmericanDateFormatter : IDateFormatter
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("d", new CultureInfo("en-US"));
    }

    public string FormatTime(DateTime time)
    {
        return time.ToString("T", new CultureInfo("en-US"));
    }
}

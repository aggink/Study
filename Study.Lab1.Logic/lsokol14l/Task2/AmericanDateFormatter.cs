using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.lsokol14l.Task2;

public class AmericanDateFormatter : IDateFormatter
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("d", CultureInfo.GetCultureInfo("en-US"));
    }

    public string FormatTime(DateTime time)
    {
        return time.ToString("T", CultureInfo.GetCultureInfo("en-US"));
    }
}

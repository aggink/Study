using Study.Lab1.Logic.Interfaces.katty.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.katty.Task2;

public class EuropeanDateTimeFormatter : IDateTimeFormatter
{
    public string FormatDateTime(DateTime dateTime)
    {
        CultureInfo culture = new CultureInfo("ru-RU");
        return dateTime.ToString("G", culture);
    }
}


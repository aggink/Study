namespace Study.Lab1.Logic.brnvika.Task2;
using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Globalization;
public class EuropeanDateFormatter : IDateFormatter
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }

    public string FormatTime(DateTime time)
    {
        return time.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
    }
}

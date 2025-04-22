namespace Study.Lab1.Logic.brnvika.Task2;
using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Globalization;

public class AmericanDateFormatter : IDateFormatter
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
    }

    public string FormatTime(DateTime time)
    {
        return time.ToString("hh:mm tt", CultureInfo.InvariantCulture);
    }
}

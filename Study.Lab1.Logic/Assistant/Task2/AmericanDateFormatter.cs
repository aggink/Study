using Study.Lab1.Logic.Interfaces.Assistant.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.Assistant.Task2
{
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
}

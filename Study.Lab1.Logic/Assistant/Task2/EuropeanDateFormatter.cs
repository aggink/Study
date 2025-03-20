using Study.Lab1.Logic.Interfaces.Assistant.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.Assistant.Task2
{
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
}

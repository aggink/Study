using System.Globalization;
using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l.Task2
{
    public class EuropeanDateFormatter : IDateFormatter
    {
        public string FormatDate(DateTime date)
        {
            return date.ToString("d", CultureInfo.GetCultureInfo("de-DE"));
        }

        public string FormatTime(DateTime time)
        {
            return time.ToString("T", CultureInfo.GetCultureInfo("de-DE"));
        }
    }
}

using System.Globalization;
using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l.Task2
{
    public class EuropeanDateFormatter : IDateFormatter
    {
        // <summary> 
        // •	CultureInfo.InvariantCulture представляет культуру, которая не зависит от языка и региона
        // </summary>
        public string FormatDate(DateTime date) { return date.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-GB")); }
        public string FormatTime(DateTime time) { return time.ToString("HH:mm:ss", CultureInfo.GetCultureInfo("en-GB")); }
    }
}

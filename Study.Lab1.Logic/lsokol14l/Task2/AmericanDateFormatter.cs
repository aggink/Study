using System.Globalization;
using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l.Task2
{
    public class AmericanDateFormatter : IDateFormatter
    {
        /// <summary> 
        /// •	CultureInfo.InvariantCulture представляет культуру, которая не зависит от языка и региона
        /// </summary>
        public string FormatDate(DateTime date) { return date.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")); }
        public string FormatTime(DateTime time) { return time.ToString("hh:mm:ss tt", CultureInfo.GetCultureInfo("en-US")); }
    }
}

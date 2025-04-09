using Study.Lab1.Logic.Interfaces.Cherryy.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.Interfaces.Cherryy.Task2
{
    public class EuropeanDateTimeFormatter : IFormatDate
    {
        private readonly CultureInfo _culture = new("en-DE");

        public string FormatDateTime()
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString(_culture));
            return sb.ToString();
        }
    }
}
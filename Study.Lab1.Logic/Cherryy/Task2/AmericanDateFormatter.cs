using Study.Lab1.Logic.Interfaces.Cherryy.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.Cherryy.Task2
{
    public class AmericanDateTimeFormatter : IDateTimeFormatter
    {
        public string Format(DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }
    }
}

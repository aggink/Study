using Study.Lab1.Logic.Interfaces.Cherryy.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.Cherryy.Task2
{
    public class EuropeanDateTimeFormatter : IDateTimeFormatter
    {
        public string Format(DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }
}

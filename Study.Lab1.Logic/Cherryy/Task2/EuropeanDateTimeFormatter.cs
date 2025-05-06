using Study.Lab1.Logic.Interfaces.Cherryy.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.Cherryy.Task2;

public class EuropeanDateTimeFormatter : IFormatDate
{
    private readonly CultureInfo _culture = new("en-DE");

    public string FormatDateTime(DateTime dateTime)
    {
        var sb = new StringBuilder();
        sb.Append(dateTime.ToString(_culture));
        return sb.ToString();
    }
}
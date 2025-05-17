using System.Globalization;
using System.Text;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;

namespace Study.Lab1.Logic.poroshok.Task2;

public class EuropeanDateTimeFormatter : IDateTimeFormatter
{
    private readonly CultureInfo _culture = new("de-DE");

    public string FormatDateTime()
    {
        var sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString(_culture));
        return sb.ToString();
    }
}

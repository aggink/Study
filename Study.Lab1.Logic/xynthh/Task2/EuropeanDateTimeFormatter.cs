using Study.Lab1.Logic.Interfaces.xynthh.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.xynthh.Task2;

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
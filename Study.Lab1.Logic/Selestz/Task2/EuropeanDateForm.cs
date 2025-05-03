using Study.Lab1.Logic.Interfaces.Selestz.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.Selestz.Task2;

public class EuropeanDateForm : IDateTimeFormatter
{
    private readonly CultureInfo _culture = new("de-DE");

    public string FormatDateTime()
    {
        var deutschland = new StringBuilder();
        deutschland.Append(DateTime.Now.ToString("g", _culture)); // Добавлено время
        return deutschland.ToString();
    }
}
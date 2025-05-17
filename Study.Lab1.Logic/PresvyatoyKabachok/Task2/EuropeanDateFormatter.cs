using Study.Lab1.Logic.Interfaces.PresvyatoyKabachok.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.PresvyatoyKabachok.Task2;

public class EuropeanDateFormatter : IDateFormatter
{
    private readonly CultureInfo _culture = new("de-DE");

    public string FormatDateTime()
    {
        var deutch = new StringBuilder();
        deutch.Append(DateTime.Now.ToString("g", _culture)); // Добавлено время
        return deutch.ToString();
    }
}

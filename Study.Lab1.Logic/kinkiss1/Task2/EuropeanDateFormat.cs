using Study.Lab1.Logic.Interfaces.kinkiss1.task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.kinkiss1.Task2;

public class EuropeanDateFormat : IFormatDate
{
    private readonly CultureInfo _culture = new("fr-FR");

    public string FormatDateTime()
    {
        var fr = new StringBuilder();
        fr.Append(DateTime.Now.ToString("g", _culture)); // Добавлено время
        return fr.ToString();
    }
}
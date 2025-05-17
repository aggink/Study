using Study.Lab1.Logic.Interfaces.PresvyatoyKabachok.Task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.PresvyatoyKabachok.Task2;

public class AmericanDateFormatter : IDateFormatter
{
    private readonly CultureInfo _culture = new("en-US");

    public string FormatDateTime()
    {
        var us = new StringBuilder();
        us.Append(DateTime.Now.ToString("g", _culture)); // Добавлено время
        return us.ToString();
    }
}

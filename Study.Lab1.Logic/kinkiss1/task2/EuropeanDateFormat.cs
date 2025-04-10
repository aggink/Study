using Study.Lab1.Logic.Interfaces.kinkiss1.task2;
using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.kinkiss1.task2;

public class EuropeanDateFormat : IFormatDate
{
    private static readonly CultureInfo _culture = new("fr-FR");

    public string DataTimeFormat()
    {
        var Fr = new StringBuilder();
        Fr.Append(DateTime.Now.ToString(_culture));
        return Fr.ToString();
    }

    string IFormatDate.European(DateTime date, DateTime time)
    {
        throw new NotImplementedException();
    }
}
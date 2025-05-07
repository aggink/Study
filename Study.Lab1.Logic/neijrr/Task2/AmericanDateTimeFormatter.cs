using System.Globalization;
using System.Text;

namespace Study.Lab1.Logic.neijrr.Task2;

public class AmericanDateTimeFormatter : DateTimeBaseFormatter
{
    private readonly CultureInfo _culture = new("en-US");

    public override StringBuilder DateTimeStringBuilder(DateTime? datetime)
    {
        return new StringBuilder(
            (datetime ?? System.DateTime.Now).ToString(_culture)
        );
    }

    public override StringBuilder DateStringBuilder(DateTime? datetime)
    {
        return new StringBuilder(
            (datetime ?? System.DateTime.Now).ToString(_culture.DateTimeFormat.ShortDatePattern)
        );
    }

    public override StringBuilder TimeStringBuilder(DateTime? datetime, bool includeSeconds)
    {
        var format = includeSeconds ? _culture.DateTimeFormat.LongTimePattern : _culture.DateTimeFormat.ShortTimePattern;
        return new StringBuilder(
            (datetime ?? System.DateTime.Now).ToString(format)
        );
    }
}

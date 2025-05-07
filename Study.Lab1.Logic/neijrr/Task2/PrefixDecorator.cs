using Study.Lab1.Logic.Interfaces.neijrr.Task2;
using System.Text;

namespace Study.Lab1.Logic.neijrr.Task2;

/// <summary>
/// Декоратор, добавляющий префикс
/// </summary>
public class PrefixDecorator(IDateTimeFormatter formatter, object prefix) : DateTimeBaseDecorator(formatter)
{
    private readonly string _prefix = prefix.ToString() ?? string.Empty;

    public override StringBuilder DateTimeStringBuilder(DateTime? datetime) =>
        _formatter.DateTimeStringBuilder(datetime).Insert(0, _prefix);

    public override StringBuilder DateStringBuilder(DateTime? datetime) =>
        _formatter.DateStringBuilder(datetime).Insert(0, _prefix);

    public override StringBuilder TimeStringBuilder(DateTime? datetime, bool includeSeconds) =>
        _formatter.TimeStringBuilder(datetime, includeSeconds).Insert(0, _prefix);
}

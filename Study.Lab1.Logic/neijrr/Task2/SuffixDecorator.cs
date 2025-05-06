using Study.Lab1.Logic.Interfaces.neijrr.Task2;
using System.Text;

namespace Study.Lab1.Logic.neijrr.Task2;

/// <summary>
/// Декоратор, добавляющий суффикс
/// </summary>
public class SuffixDecorator(IDateTimeFormatter formatter, object suffix) : DateTimeBaseDecorator(formatter)
{
    private readonly string _suffix = suffix.ToString() ?? string.Empty;

    public override StringBuilder DateTimeStringBuilder(DateTime? datetime) =>
        _formatter.DateTimeStringBuilder(datetime).Append(_suffix);

    public override StringBuilder DateStringBuilder(DateTime? datetime) =>
        _formatter.DateStringBuilder(datetime).Append(_suffix);

    public override StringBuilder TimeStringBuilder(DateTime? datetime, bool includeSeconds) =>
        _formatter.TimeStringBuilder(datetime, includeSeconds).Append(_suffix);
}

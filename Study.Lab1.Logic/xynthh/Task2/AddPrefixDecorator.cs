using Study.Lab1.Logic.Interfaces.xynthh.Task2;
using System.Text;

namespace Study.Lab1.Logic.xynthh.Task2;

/// <summary>
/// Декоратор добавляющий префикс к строке даты и времени
/// </summary>
public class AddPrefixDecorator : DateTimeDecoratorBase
{
    private readonly string _prefix;

    public AddPrefixDecorator(IDateTimeFormatter wrappedFormatter, string prefix) : base(wrappedFormatter)
    {
        _prefix = prefix ?? string.Empty;
    }

    public override string FormatDateTime()
    {
        var sb = new StringBuilder();

        sb.Append(_prefix);
        sb.Append(WrappedFormatter.FormatDateTime());

        return sb.ToString();
    }
}
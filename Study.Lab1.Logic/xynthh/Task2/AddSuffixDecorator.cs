using Study.Lab1.Logic.Interfaces.xynthh.Task2;
using System.Text;

namespace Study.Lab1.Logic.xynthh.Task2;

/// <summary>
/// Декоратор добавляющий суффикс к строке даты и времени 
/// </summary>
public class AddSuffixDecorator : DateTimeDecoratorBase
{
    private readonly string _suffix;

    public AddSuffixDecorator(IDateTimeFormatter wrappedFormatter, string suffix) : base(wrappedFormatter)
    {
        _suffix = suffix ?? string.Empty;
    }

    public override string FormatDateTime()
    {
        var sb = new StringBuilder();

        sb.Append(WrappedFormatter.FormatDateTime());
        sb.Append(_suffix);

        return sb.ToString();
    }
}
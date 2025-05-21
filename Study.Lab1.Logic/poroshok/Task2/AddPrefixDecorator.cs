using System.Text;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;

namespace Study.Lab1.Logic.poroshok.Task2;

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
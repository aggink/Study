using System.Text;
using Study.Lab1.Logic.Interfaces.poroshok.Task2;

namespace Study.Lab1.Logic.poroshok.Task2;

public class AddBracketsDecorator : DateTimeDecoratorBase
{
    public AddBracketsDecorator(IDateTimeFormatter wrappedFormatter) : base(wrappedFormatter)
    {
    }

    public override string FormatDateTime()
    {
        var sb = new StringBuilder();
        sb.Append("[");
        sb.Append(WrappedFormatter.FormatDateTime());
        sb.Append("]");
        return sb.ToString();
    }
}

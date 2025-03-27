using System.Text;
using Study.Lab1.Logic.Interfaces.xynthh.Task2;

namespace Study.Lab1.Logic.xynthh.Task2;

/// <summary>
/// Декоратор добавляющий скобки до и после даты
/// </summary>
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
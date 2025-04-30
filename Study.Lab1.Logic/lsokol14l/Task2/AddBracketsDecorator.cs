using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;
using System.Text;

namespace Study.Lab1.Logic.lsokol14l.Task2;

public class AddBracketsDecorator : DateTimeDecoratorBase
{
    /// <param name="wrappedFormatter">Принимает в себя ссылку на объект реализующий интерфейс IDatetimeFormatter</param>
    public AddBracketsDecorator(IDateFormatter wrappedFormatter) : base(wrappedFormatter)
    {
    }

    public override string FormatDate(DateTime date)
    {
        var sb = new StringBuilder();

        sb.Append("[");
        sb.Append(WrappedFormatter.FormatDate(date));
        sb.Append(']');

        // формирует строку на основе данных в объекте sb
        return sb.ToString();
    }

    public override string FormatTime(DateTime time)
    {
        var sb = new StringBuilder();

        sb.Append("[");
        sb.Append(WrappedFormatter.FormatTime(time));
        sb.Append(']');

        // формирует строку на основе данных в объекте sb
        return sb.ToString();
    }
}

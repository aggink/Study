using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;
using System.Text;

namespace Study.Lab1.Logic.lsokol14l.Task2;

public class AddPostfixDecorator : DateTimeDecoratorBase
{
    private readonly string _postfix;

    /// <param name="wrappedFormatter">Принимает в себя ссылку на объект реализующий интерфейс IDatetimeFormatter</param>
    public AddPostfixDecorator(IDateFormatter wrappedFormatter, string postfix) : base(wrappedFormatter)
    {
        _postfix = postfix;
    }

    public override string FormatDate(DateTime date)
    {
        var sb = new StringBuilder();

        sb.Append(WrappedFormatter.FormatDate(date));
        sb.Append(_postfix);

        return sb.ToString();
    }

    public override string FormatTime(DateTime time)
    {
        var sb = new StringBuilder();

        sb.Append(WrappedFormatter.FormatTime(time));
        sb.Append(_postfix);

        return sb.ToString();
    }

}

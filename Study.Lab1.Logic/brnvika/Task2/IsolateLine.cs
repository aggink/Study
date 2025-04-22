using Study.Lab1.Logic.Interfaces.brnvika.Task2;
using System.Text;
namespace Study.Lab1.Logic.brnvika.Task2;

public class IsolateLine : BaseDateDecorator
{
    private readonly string _line = "";

    public IsolateLine(IDateFormatter dateFormatter, string line) : base(dateFormatter)
    {
        _line = line;
    }

    public override string FormatDate(DateTime date)
    {
        var DecorateDate = new StringBuilder();
        DecorateDate.Append(_line);
        DecorateDate.Append(_dateFormatter.FormatDate(date));
        DecorateDate.Append(_line);
        return DecorateDate.ToString();

        throw new NotImplementedException();
    }

    public override string FormatTime(DateTime date)
    {
        var DecorateDate = new StringBuilder();
        DecorateDate.Append(_line);
        DecorateDate.Append(_dateFormatter.FormatTime(date));
        DecorateDate.Append(_line);
        return DecorateDate.ToString();

        throw new NotImplementedException();
    }
}

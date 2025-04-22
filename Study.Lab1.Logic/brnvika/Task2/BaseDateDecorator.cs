using Study.Lab1.Logic.Interfaces.brnvika.Task2;
namespace Study.Lab1.Logic.brnvika.Task2;

public abstract class BaseDateDecorator : IDateFormatter
{
    protected IDateFormatter _dateFormatter;
    protected BaseDateDecorator(IDateFormatter dateFormatter)
    {
        _dateFormatter = dateFormatter;
    }
    public abstract string FormatDate(DateTime date);
    public abstract string FormatTime(DateTime time);
}

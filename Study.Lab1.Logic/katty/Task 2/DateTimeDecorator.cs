using Study.Lab1.Logic.Interfaces.katty.Task2;

namespace Study.Lab1.Logic.katty.Task_2;

public class DateTimeDecorator : IDateTimeFormatter
{
    protected IDateTimeFormatter _formatter;

    protected DateTimeDecorator(IDateTimeFormatter formatter)
    {
        _formatter = formatter;
    }

    public virtual string FormatDateTime(DateTime dateTime)
    {
        return _formatter.FormatDateTime(dateTime);
    }
}

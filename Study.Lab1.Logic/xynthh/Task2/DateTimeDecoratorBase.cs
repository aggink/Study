using Study.Lab1.Logic.Interfaces.xynthh.Task2;

namespace Study.Lab1.Logic.xynthh.Task2;

public abstract class DateTimeDecoratorBase : IDateTimeFormatter
{
    protected readonly IDateTimeFormatter WrappedFormatter;

    public abstract string FormatDateTime();

    protected DateTimeDecoratorBase(IDateTimeFormatter wrappedFormatter)
    {
        WrappedFormatter = wrappedFormatter ?? throw new ArgumentNullException(nameof(wrappedFormatter));
    }
}
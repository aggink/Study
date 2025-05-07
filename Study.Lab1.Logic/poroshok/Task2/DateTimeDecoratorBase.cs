using Study.Lab1.Logic.Interfaces.poroshok.Task2;

namespace Study.Lab1.Logic.poroshok.Task2;

public abstract class DateTimeDecoratorBase : IDateTimeFormatter
{
    protected readonly IDateTimeFormatter WrappedFormatter;

    protected DateTimeDecoratorBase(IDateTimeFormatter wrappedFormatter)
    {
        WrappedFormatter = wrappedFormatter ?? throw new ArgumentNullException(nameof(wrappedFormatter));
    }

    public abstract string FormatDateTime();
}
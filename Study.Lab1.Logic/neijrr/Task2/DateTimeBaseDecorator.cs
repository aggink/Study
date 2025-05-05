using Study.Lab1.Logic.Interfaces.neijrr.Task2;

namespace Study.Lab1.Logic.neijrr.Task2;

public abstract class DateTimeBaseDecorator(IDateTimeFormatter formatter) : DateTimeBaseFormatter
{
    protected readonly IDateTimeFormatter _formatter = formatter
        ?? throw new ArgumentNullException(nameof(formatter), $"{nameof(formatter)} не может быть равен null");
}

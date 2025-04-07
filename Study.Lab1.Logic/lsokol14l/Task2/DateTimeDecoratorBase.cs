using Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

namespace Study.Lab1.Logic.lsokol14l.Task2;


/// <summary>
/// Класс DateTimeDecoratorBase является абстрактным базовым классом для декораторов,
/// которые реализуют интерфейс IDateFormatter.
/// Декоратор — это структурный паттерн проектирования,
/// который позволяет динамически добавлять поведение объектам, оборачивая их в другой объект.
/// </summary>
public abstract class DateTimeDecoratorBase : IDateFormatter
{
    /// <summary>
    /// Это защищенное поле, которое хранит ссылку на объект,
    /// реализующий интерфейс `IDateFormatter`. Этот объект будет декорироваться.
    /// </summary>
    /// <param name="wrappedFormatter">Объект, реализующий интерфейс IDateFormatter</param>
    protected readonly IDateFormatter WrappedFormatter;

    /// <summary>
    /// Конструктор принимает объект, реализующий `IDateFormatter`, и сохраняет его в поле `WrappedFormatter`.
    /// Если переданный объект равен `null`, выбрасывается исключение `ArgumentNullException`.
    /// </summary>
    protected DateTimeDecoratorBase(IDateFormatter wrappedFormatter)
    {
        WrappedFormatter = wrappedFormatter ?? throw new ArgumentNullException(nameof(wrappedFormatter));
    }

    public abstract string FormatDate(DateTime date);
    public abstract string FormatTime(DateTime time);
}
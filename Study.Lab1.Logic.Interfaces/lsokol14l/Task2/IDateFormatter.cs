namespace Study.Lab1.Logic.Interfaces.lsokol14l.Task2;

/// <summary>
/// Интерфейс DateFormatter определяем поведение(описываем методы) все поля по умолчанию public
/// присутствует модификатор protected для реализации методов "по умолчанию"
/// </summary>
public interface IDateFormatter
{
    /// <summary>
    /// Форматирование даты
    /// </summary>
    /// <param name="date">Дата</param>
    /// <returns>Текстовое представление даты</returns>
    string FormatDate(DateTime date);

    /// <summary>
    /// Форматирование времени
    /// </summary>
    /// <param name="time">Время</param>
    /// <returns>Текстовое представление времени</returns>
    string FormatTime(DateTime time);
}
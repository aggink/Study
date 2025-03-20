namespace Study.Lab1.Logic.Interfaces.Assistant.Task2
{
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
}

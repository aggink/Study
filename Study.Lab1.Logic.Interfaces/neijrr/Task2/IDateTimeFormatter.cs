using System.Text;

namespace Study.Lab1.Logic.Interfaces.neijrr.Task2;

public interface IDateTimeFormatter
{
    /// <summary>
    /// Форматирует дату и время
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <returns>
    /// Объект StringBuilder с представлением даты и времени
    /// </returns>
    StringBuilder DateTimeStringBuilder(DateTime? datetime);

    /// <summary>
    /// Форматирует дату, игнорируя время
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <returns>
    /// Объект StringBuilder с представлением даты
    /// </returns>
    StringBuilder DateStringBuilder(DateTime? datetime);

    /// <summary>
    /// Форматирует время, игнорируя дату
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <param name="includeSeconds">
    /// Если false, секунды не будут выведены; по умолчанию - true
    /// </param>
    /// <returns>
    /// Объект StringBuilder с представлением времени
    /// </returns>
    StringBuilder TimeStringBuilder(DateTime? datetime, bool includeSeconds);

    /// <summary>
    /// Форматирует дату и время
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <returns>
    /// Текстовое представление даты и времени
    /// </returns>
    string DateTime(DateTime? datetime);

    /// <summary>
    /// Форматирует дату, игнорируя время
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <returns>
    /// Текстовое представление даты
    /// </returns>
    string Date(DateTime? datetime);

    /// <summary>
    /// Форматирует время, игнорируя дату
    /// </summary>
    /// <param name="datetime">
    /// Форматируемая дата и время; по умолчанию используется текущее время
    /// </param>
    /// <param name="includeSeconds">
    /// Если false, секунды не будут выведены; по умолчанию - true
    /// </param>
    /// <returns>
    /// Текстовое представление времени
    /// </returns>
    string Time(DateTime? datetime, bool includeSeconds);
}

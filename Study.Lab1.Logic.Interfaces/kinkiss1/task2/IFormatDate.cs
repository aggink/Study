namespace Study.Lab1.Logic.Interfaces.kinkiss1.task2;

public interface IFormatDate
{
    /// <summary>
    /// Европейское форматирование даты и времени (дд.мм.гггг чч:мм:сс)
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="time">Время</param>
    /// <returns> Текстовое представление даты и времени в Европейском стиле</returns>
    public string European(DateTime date, DateTime time);
}
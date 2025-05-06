namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IResponseProcessor
{
    /// <summary>
    /// Форматирует JSON строку с десериализацией в указанный тип
    /// </summary>
    /// <typeparam name="T">Тип для десериализации</typeparam>
    /// <param name="rawJson">Исходная JSON строка</param>
    /// <returns>Форматированная JSON строка</returns>
    string FormatJson<T>(string rawJson) where T : class;
}
namespace Study.Lab2.Logic.Interfaces.chaspix;

public interface IResponseProcessor
{
    /// <summary>
    /// Форматирует JSON ответ для красивого вывода
    /// </summary>
    string FormatJsonResponse(string jsonResponse);

    /// <summary>
    /// Проверяет наличие ошибок в ответе
    /// </summary>
    bool HasError(string response);

    /// <summary>
    /// Извлекает сообщение об ошибке
    /// </summary>
    string ExtractErrorMessage(string response);
}

namespace Study.Lab2.Logic.Interfaces.xynthh;

public interface IResponseProcessor
{
    /// <summary>
    /// Форматирует в JSON для вывода
    /// </summary>
    /// <param name="jsonResponse">Исходный JSON-ответ</param>
    /// <returns>Отформатированный JSON</returns>
    string FormatJsonResponse(string jsonResponse);

    /// <summary>
    /// Проверяет на наличие ошибок в ответе
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>True, если ответ содержит ошибку</returns>
    bool HasError(string response);

    /// <summary>
    /// Извлекает сообщение об ошибке из ответа
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>Текст ошибки</returns>
    string ExtractErrorMessage(string response);
}
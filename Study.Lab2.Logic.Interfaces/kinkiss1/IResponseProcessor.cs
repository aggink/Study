namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IResponseProcessor
{
    /// <summary>
    /// Форматирует в JSON для вывода
    /// </summary>
    /// <param name="jsonAnsw">Исходный JSON-ответ</param>
    /// <returns>Отформатированный JSON</returns>
    string FormatJsonAnswers(string jsonAnsw);

    /// <summary>
    /// Проверяет на наличие ошибок в ответе
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>True, если ответ содержит ошибку</returns>
    bool Error(string response);

    /// <summary>
    /// Извлекает сообщение об ошибке из ответа
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>Текст ошибки</returns>
    string CocnlusionErrorMessage(string response);
}

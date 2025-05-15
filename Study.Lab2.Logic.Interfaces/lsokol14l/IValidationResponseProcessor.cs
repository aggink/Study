namespace Study.Lab2.Logic.Interfaces.lsokol14l;

public interface IValidationResponseProcessor
{
    /// <summary>
    /// Обрабатывает ответ и преобразует его в объект указанного типа.
    /// </summary>
    /// <typeparam name="T">Тип объекта, в который нужно преобразовать ответ.</typeparam>
    /// <param name="response">Ответ в виде строки.</param>
    /// <returns>Объект типа <typeparamref name="T"/>.</returns>
    public T ProcessResponse<T>(string response);
}


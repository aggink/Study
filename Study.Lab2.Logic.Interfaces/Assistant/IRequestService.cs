namespace Study.Lab2.Logic.Interfaces.Assistant
{
    public interface IRequestService
    {
        /// <summary>
        /// Отправить запрос к сервису
        /// </summary>
        /// <param name="url">Веб-адрес</param>
        /// <returns>Ответ от сервиса</returns>
        string FetchData(string url);

        /// <summary>
        /// Отправить запрос к сервису
        /// </summary>
        /// <param name="url">Веб-адрес</param>
        /// <returns>Ответ от сервиса</returns>
        Task<string> FetchDataAsync(string url);
    }
}

namespace Study.Lab2.Logic.Interfaces.Cherryy
{
    public interface IRequestService : IDisposable
    {
        /// <summary>
        /// Синхронный метод выполнения HTTP-запроса
        /// </summary>
        string FetchData(string url);

        /// <summary>
        /// Асинхронный метод выполнения HTTP-запроса
        /// </summary>
        Task<string> FetchDataAsync(string url, CancellationToken cancellationToken);
    }
}

namespace Study.Lab2.Logic.Interfaces.chaspix;

public interface IServerRequestService : IDisposable
{
    /// <summary>
    /// Получить случайный пост от JSONPlaceholder
    /// </summary>
    string GetRandomPost();

    /// <summary>
    /// Получить информацию о погоде
    /// </summary>
    string GetWeatherInfo(string city);

    /// <summary>
    /// Получить случайный факт о кошках
    /// </summary>
    string GetCatFact();

    /// <summary>
    /// Асинхронно получить случайный пост
    /// </summary>
    Task<string> GetRandomPostAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронно получить информацию о погоде
    /// </summary>
    Task<string> GetWeatherInfoAsync(string city, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронно получить факт о кошках
    /// </summary>
    Task<string> GetCatFactAsync(CancellationToken cancellationToken = default);
}
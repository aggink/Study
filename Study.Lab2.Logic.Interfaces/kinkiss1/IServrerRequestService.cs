namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IServerRequestService : IDisposable
{
    /// <summary>
    /// Синхронная версия получения фактов о кошках
    /// </summary>
    string CatGetFacts();

    /// <summary>
    /// Синхронная версия получения цитаты Канье
    /// </summary>
    string KanyeRest();

    /// <summary>
    /// Асинхронная версия получения фактов о кошках
    /// </summary>
    /// <paparam name="cancellationToken">Токен отмены</param>
    Task<string> CatGetFactsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронная версия получения цитаты Канье
    /// </summary>
    /// <paparam name="cancellationToken">Токен отмены</param>
    Task<string> KanyeRestAsync(CancellationToken cancellationToken = default);
}
namespace Study.Lab2.Logic.Interfaces.mariabyrrrrak
{
    public interface IRequestService : IDisposable
    {
        string FetchData(string url);

        Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
    }
}

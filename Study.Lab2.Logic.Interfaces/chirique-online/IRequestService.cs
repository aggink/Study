namespace Study.Lab2.Logic.Interfaces.chirique_online;

public interface IRequestService : IDisposable
{
    string FetchData(string url);

    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}

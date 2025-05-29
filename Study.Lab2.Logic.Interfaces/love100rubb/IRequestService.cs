namespace Study.Lab2.Logic.Interfaces.love100rubb;

public interface IRequestService : IDisposable
{
    string FetchData(string url);

    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}


namespace Study.Lab2.Logic.Interfaces.baldfromazzers;

public interface IRequestService : IDisposable
{
    string FetchData(string url);

    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}

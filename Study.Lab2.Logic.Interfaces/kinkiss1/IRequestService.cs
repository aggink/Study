namespace Study.Lab2.Logic.Interfaces.kinkiss1;

public interface IRequestService : IDisposable
{
    string FetchData(string url);
    string FetchData(string url, Dictionary<string, string> headers);
    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}
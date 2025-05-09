namespace Study.Lab2.Logic.Interfaces.Selestz;

public interface IRequestService : IDisposable
{
    string FetchData(string url, Dictionary<string, string> headers = null);
    Task<string> FetchDataAsync(string url, Dictionary<string, string> headers = null, CancellationToken cancellationToken = default);
}
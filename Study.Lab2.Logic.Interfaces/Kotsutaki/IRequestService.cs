namespace Study.Lab2.Logic.Interfaces.Kotsutaki;

public interface IRequestService
{
    string FetchData(string url);

    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
    void Dispose();
}
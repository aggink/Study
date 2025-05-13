namespace Study.Lab2.Logic.Interfaces.katty;

public interface IRequestService
{
    string SendRequest(string url);

    Task<string> SendRequestAsync(string url, CancellationToken cancellationToken = default);
}
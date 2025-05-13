namespace Study.Lab2.Logic.Interfaces.katty;

public interface IServerRequestService : IDisposable
{
    (List<string> Responses, long ElapsedTime) ExecuteRequests();

    Task<(List<string> Responses, long ElapsedTime)> ExecuteRequestsAsync(CancellationToken cancellationToken = default);
}
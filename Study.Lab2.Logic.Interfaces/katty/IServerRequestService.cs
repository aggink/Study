namespace Study.Lab2.Logic.Interfaces.katty;
public interface IServerRequestService : IDisposable
{
    void ExecuteRequests();

    Task ExecuteRequestsAsync(CancellationToken cancellationToken = default);
}
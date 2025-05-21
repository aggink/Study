namespace Study.Lab2.Logic.Interfaces.Selestz;

public interface IServerRequestService : IDisposable
{
    string GetRandomUser();
    string GetRandomPost();
    string GetRandomTodo();

    Task<string> GetRandomUserAsync(CancellationToken cancellationToken = default);
    Task<string> GetRandomPostAsync(CancellationToken cancellationToken = default);
    Task<string> GetRandomTodoAsync(CancellationToken cancellationToken = default);
}
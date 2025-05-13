using Study.Lab2.Logic.Interfaces.katty;
using System.Diagnostics;

namespace Study.Lab2.Logic.katty;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService _requestService;
    private readonly IResponseProcessor _responseProcessor;
    private readonly string[] _serverUrls =
    {
            "https://jsonplaceholder.typicode.com/todos/1",
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/users/1"
        };
    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        _responseProcessor = responseProcessor ?? throw new ArgumentNullException(nameof(responseProcessor));
    }
    public void ExecuteRequests()
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            Console.WriteLine("Начало выполнения синхронных запросов...");
            foreach (var serverUrl in _serverUrls)
            {
                Console.WriteLine($"Отправка запроса к серверу: {serverUrl}");
                var response = _requestService.SendRequest(serverUrl);
                if (!_responseProcessor.IsSuccessResponse(response))
                {
                    Console.WriteLine($"Получен негативный ответ от сервера: {response}");
                    throw new Exception($"Ошибка при выполнении запроса к {serverUrl}: {response}");
                }
                var formattedResponse = _responseProcessor.ProcessResponse(response);
                Console.WriteLine($"Ответ от сервера {serverUrl}:\n{formattedResponse}\n");
            }
            stopwatch.Stop();
            Console.WriteLine($"Все запросы выполнены успешно. Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Время до возникновения ошибки: {stopwatch.ElapsedMilliseconds} мс");
            throw;
        }
    }
    public async Task ExecuteRequestsAsync(CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            Console.WriteLine("Начало выполнения асинхронных запросов...");
            var tasks = new Task<string>[_serverUrls.Length];
            for (int i = 0; i < _serverUrls.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine($"Отправка асинхронного запроса к серверу: {_serverUrls[i]}");
                tasks[i] = _requestService.SendRequestAsync(_serverUrls[i], cancellationToken);
            }
            await Task.WhenAll(tasks);
            for (int i = 0; i < _serverUrls.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var response = tasks[i].Result;
                if (!_responseProcessor.IsSuccessResponse(response))
                {
                    Console.WriteLine($"Получен негативный ответ от сервера: {response}");
                    throw new Exception($"Ошибка при выполнении запроса к {_serverUrls[i]}: {response}");
                }
                var formattedResponse = _responseProcessor.ProcessResponse(response);
                Console.WriteLine($"Ответ от сервера {_serverUrls[i]}:\n{formattedResponse}\n");
            }
            stopwatch.Stop();
            Console.WriteLine($"Все асинхронные запросы выполнены успешно. Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Время до возникновения ошибки: {stopwatch.ElapsedMilliseconds} мс");
            throw;
        }
    }

    public void Dispose()
    {
        /*реализация для dispose не продумана в моей реализации, но требуется в наследуемом интерфейсе, такие дела, останется пустой метод
        с возможной будущей реализацией*/
    }
}

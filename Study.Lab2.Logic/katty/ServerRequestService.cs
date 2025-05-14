using Study.Lab2.Logic.Interfaces.katty;
using Study.Lab2.Logic.katty.DtoModels;
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

    private readonly Dictionary<string, Type> _urlToDtoTypeMap = new()
    {
        { "https://jsonplaceholder.typicode.com/todos/1", typeof(TodoDto) },
        { "https://jsonplaceholder.typicode.com/posts/1", typeof(PostDto) },
        { "https://jsonplaceholder.typicode.com/users/1", typeof(UserDto) }
    };

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        _responseProcessor = responseProcessor ?? throw new ArgumentNullException(nameof(responseProcessor));
    }

    public (List<string> Responses, long ElapsedTime) ExecuteRequests()
    {
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            foreach (var serverUrl in _serverUrls)
            {
                var response = _requestService.SendRequest(serverUrl);
                var dtoType = _urlToDtoTypeMap[serverUrl];

                bool isSuccess = (bool)typeof(IResponseProcessor)
                    .GetMethod(nameof(IResponseProcessor.IsSuccessResponse))
                    ?.MakeGenericMethod(dtoType)
                    .Invoke(_responseProcessor, new[] { response })!;

                if (!isSuccess)
                {
                    throw new Exception($"Ошибка при выполнении запроса к {serverUrl}: {response}");
                }

                string formattedResponse = (string)typeof(IResponseProcessor)
                    .GetMethod(nameof(IResponseProcessor.ProcessResponse))
                    ?.MakeGenericMethod(dtoType)
                    .Invoke(_responseProcessor, new[] { response })!;

                responses.Add($"Ответ от сервера {serverUrl}:\n{formattedResponse}");
            }

            stopwatch.Stop();
            return (responses, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception)
        {
            stopwatch.Stop();
            throw;
        }
    }

    public async Task<(List<string> Responses, long ElapsedTime)> ExecuteRequestsAsync(CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            var tasks = new Task<(string Response, string Url)>[_serverUrls.Length];

            for (int i = 0; i < _serverUrls.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var url = _serverUrls[i];
                tasks[i] = _requestService.SendRequestAsync(url, cancellationToken)
                    .ContinueWith(t => (t.Result, url), cancellationToken);
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var (response, url) = task.Result;
                var dtoType = _urlToDtoTypeMap[url];

                bool isSuccess = (bool)typeof(IResponseProcessor)
                    .GetMethod(nameof(IResponseProcessor.IsSuccessResponse))
                    ?.MakeGenericMethod(dtoType)
                    .Invoke(_responseProcessor, new[] { response })!;

                if (!isSuccess)
                {
                    throw new Exception($"Ошибка при выполнении запроса к {url}: {response}");
                }
                string formattedResponse = (string)typeof(IResponseProcessor)
                    .GetMethod(nameof(IResponseProcessor.ProcessResponse))
                    ?.MakeGenericMethod(dtoType)
                    .Invoke(_responseProcessor, new[] { response })!;

                responses.Add($"Ответ от сервера {url}:\n{formattedResponse}");
            }

            stopwatch.Stop();
            return (responses, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception)
        {
            stopwatch.Stop();
            throw;
        }
    }

    public void Dispose() => Console.WriteLine("Тут будет реализован Dispose");
}
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces.Selestz;
using Study.Lab2.Logic.Selestz.DtoModels;

namespace Study.Lab2.Logic.Selestz;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService _requestService;
    private readonly IResponseProcessor _responseProcessor;
    private readonly Random _random = new Random();

    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService;
        _responseProcessor = responseProcessor;
    }

    public string GetRandomUser()
    {
        var randomId = _random.Next(1, 11);
        var url = $"{BaseUrl}/users/{randomId}";
        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var user = _responseProcessor.FormatJsonResponse<UserDto>(response);
        return JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
    }

    public string GetRandomPost()
    {
        var randomId = _random.Next(1, 101);
        var url = $"{BaseUrl}/posts/{randomId}";
        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var post = _responseProcessor.FormatJsonResponse<PostDto>(response);
        return JsonSerializer.Serialize(post, new JsonSerializerOptions { WriteIndented = true });
    }

    public string GetRandomTodo()
    {
        var randomId = _random.Next(1, 151);
        var url = $"{BaseUrl}/todos/{randomId}";
        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var todo = _responseProcessor.FormatJsonResponse<TodoDto>(response);
        return JsonSerializer.Serialize(todo, new JsonSerializerOptions { WriteIndented = true });
    }

    public async Task<string> GetRandomUserAsync(CancellationToken cancellationToken = default)
    {
        var randomId = _random.Next(1, 11);
        var url = $"{BaseUrl}/users/{randomId}";
        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var user = _responseProcessor.FormatJsonResponse<UserDto>(response);
        return JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
    }

    public async Task<string> GetRandomPostAsync(CancellationToken cancellationToken = default)
    {
        var randomId = _random.Next(1, 101);
        var url = $"{BaseUrl}/posts/{randomId}";
        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var post = _responseProcessor.FormatJsonResponse<PostDto>(response);
        return JsonSerializer.Serialize(post, new JsonSerializerOptions { WriteIndented = true });
    }

    public async Task<string> GetRandomTodoAsync(CancellationToken cancellationToken = default)
    {
        var randomId = _random.Next(1, 151);
        var url = $"{BaseUrl}/todos/{randomId}";
        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        var todo = _responseProcessor.FormatJsonResponse<TodoDto>(response);
        return JsonSerializer.Serialize(todo, new JsonSerializerOptions { WriteIndented = true });
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
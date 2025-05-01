using Study.Lab2.Logic.Interfaces.xynthh;

namespace Study.Lab2.Logic.xynthh;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService    _requestService;
    private readonly IResponseProcessor _responseProcessor;

    // Базовые URL для API
    private const string JsonPlaceholderBaseUrl = "https://jsonplaceholder.typicode.com";
    private const string ReqResBaseUrl          = "https://reqres.in/api";

    // Заголовки для разных API
    private readonly Dictionary<string, string> _reqresHeaders;

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService;
        _responseProcessor = responseProcessor;

        // Инициализация заголовков для ReqRes API
        _reqresHeaders = new Dictionary<string, string>
        {
            { "x-api-key", "reqres-free-v1" }
        };
    }

    public string GetJsonPlaceholderUser(int userId)
    {
        var url = $"{JsonPlaceholderBaseUrl}/users/{userId}";
        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public string GetReqResUser(int userId)
    {
        var url = $"{ReqResBaseUrl}/users/{userId}";
        var response = _requestService.FetchData(url, _reqresHeaders);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public string GetJsonPlaceholderPost(int postId)
    {
        var url = $"{JsonPlaceholderBaseUrl}/posts/{postId}";
        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public async Task<string> GetJsonPlaceholderUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var url = $"{JsonPlaceholderBaseUrl}/users/{userId}";
        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public async Task<string> GetReqResUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var url = $"{ReqResBaseUrl}/users/{userId}";
        var response = await _requestService.FetchDataAsync(url, _reqresHeaders, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public async Task<string> GetJsonPlaceholderPostAsync(int postId, CancellationToken cancellationToken = default)
    {
        var url = $"{JsonPlaceholderBaseUrl}/posts/{postId}";
        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        return _responseProcessor.FormatJsonResponse(response);
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
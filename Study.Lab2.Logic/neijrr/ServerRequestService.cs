using Study.Lab2.Logic.Interfaces.neijrr;

namespace Study.Lab2.Logic.neijrr;

public class ServerRequestService(
    string Url, IRequestService requestService = null, IResponseProcessor responseProcessor = null
) : IServerRequestService
{
    private readonly IRequestService _requestService = requestService ?? new RequestService(new HttpClient());

    private readonly IResponseProcessor _responseProcessor = responseProcessor ?? new ResponseProcessor();

    private readonly UrlBuilder _urlBuilder = new(Url);

    public IPost GetPost(int id)
    {
        var url = _urlBuilder.Url(["posts", id]);
        var response = _requestService.FetchData(url);

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        return new Post(json);
    }

    public int SendPost(int userId, string title, string body)
    {
        var url = _urlBuilder.Url(["posts"], parameters: new() { { "postId", userId } });
        var requestBody = new Dictionary<string, object>() { { "title", title }, { "body", body }, { "userId", userId } };
        var response = _requestService.SendData(
            url, HttpMethod.Post, _responseProcessor.ToJsonString(requestBody)
        );

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        if (!json.RootElement.TryGetProperty("id", out var idProperty))
            throw new Exception("В ответе отсутствует id");

        if (!idProperty.TryGetInt32(out var id))
            throw new Exception("id не является числом");

        return id;
    }

    public IPost UpdatePost(int id, string title = null, string body = null)
    {
        var url = _urlBuilder.Url(["posts", id]);

        var requestBody = new Dictionary<string, string>();
        if (title is not null)
            requestBody.Add("title", title);
        if (body is not null)
            requestBody.Add("body", body);

        var response = _requestService.SendData(
            url, HttpMethod.Patch, _responseProcessor.ToJsonString(requestBody)
        );

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        return new Post(json);
    }

    public async Task<IPost> GetPostAsync(int id, CancellationToken cancellationToken = default)
    {
        var url = _urlBuilder.Url(["posts", id]);
        var response = await _requestService.FetchDataAsync(url, cancellationToken);

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        return new Post(json);
    }

    public async Task<int> SendPostAsync(int userId, string title, string body, CancellationToken cancellationToken = default)
    {
        var url = _urlBuilder.Url(["posts"], parameters: new() { { "postId", userId } });
        var requestBody = new Dictionary<string, object>() { { "title", title }, { "body", body }, { "userId", userId } };
        var response = await _requestService.SendDataAsync(
            url, HttpMethod.Post, _responseProcessor.ToJsonString(requestBody), cancellationToken
        );

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        if (!json.RootElement.TryGetProperty("id", out var idProperty))
            throw new Exception("В ответе отсутствует id");

        if (!idProperty.TryGetInt32(out var id))
            throw new Exception("id не является числом");

        return id;
    }

    public async Task<IPost> UpdatePostAsync(int id, string title = null, string body = null, CancellationToken cancellationToken = default)
    {
        var url = _urlBuilder.Url(["posts", id]);

        var requestBody = new Dictionary<string, string>();
        if (title is not null)
            requestBody.Add("title", title);
        if (body is not null)
            requestBody.Add("body", body);

        var response = await _requestService.SendDataAsync(
            url, HttpMethod.Patch, _responseProcessor.ToJsonString(requestBody), cancellationToken
        );

        var json = _responseProcessor.ToJsonDocument(response) ?? throw new Exception("Ошибка обработки ответа сервера");
        var error = _responseProcessor.GetErrorMessage(json);

        if (error is not null)
            throw new Exception(error);

        return new Post(json);
    }

    public void Dispose()
    {
        _requestService?.Dispose();
        GC.SuppressFinalize(this);
    }
}

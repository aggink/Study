using Study.Lab2.Logic.Interfaces.kinkiss1;
using System.Text;
using System.Text.Json;

namespace Study.Lab2.Logic.kinkiss1;

public class ServerRequestService : IServerRequestService
{
    private readonly Dictionary<string, string> _Headers;
    private readonly IRequestService _rService;
    private readonly IResponseProcessor _rProcessor;

    private const string JsonBaseUrl = "https://jsonplaceholder.typicode.com";
    private const string ReqresBaseUrl = "https://reqres.in/api";
    private const string CatBaseUrl = "https://catfact.ninja";
    private const string TranslateBaseUrl = "https://libretranslate.com/translate";

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _rService = requestService;
        _rProcessor = responseProcessor;

        _Headers = new Dictionary<string, string>
        {
            { "x-api-key", "reqres-free-v1" }
        };
    }

    public string JsonGetUser(int userId)
    {
        var url = $"{JsonBaseUrl}/users/{userId}";
        var answer = _rService.FetchSync(url);

        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));

        return _rProcessor.FormatJsonAnswers(answer);
    }
    
    public string CatGetFacts()
    {
        var url = $"{CatBaseUrl}/fact";
        var answer = _rService.FetchSync(url);

        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));

        var jsonResponse = JsonDocument.Parse(answer);
        var factText = jsonResponse.RootElement.GetProperty("fact").GetString();

        var formattedJson = JsonSerializer.Serialize(new { fact = factText }, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        return formattedJson;
    }

    public string ReqresGetUser(int userId)
    {
        var url = $"{ReqresBaseUrl}/users/{userId}";
        var answer = _rService.FetchSync(url, _Headers);

        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));

        return _rProcessor.FormatJsonAnswers(answer);
    }

    public string JsonGetPost(int postId)
    {
        var url = $"{JsonBaseUrl}/posts/{postId}";
        var answer = _rService.FetchSync(url, _Headers);
        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));
        return _rProcessor.FormatJsonAnswers(answer);
    }

    public async Task<string> JsonGetUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var url = $"{JsonBaseUrl}/users/{userId}";
        var answer = await _rService.FetchAsync(url, _Headers, cancellationToken);

        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));

        return _rProcessor.FormatJsonAnswers(answer);
    }


    public async Task<string> ReqresGetUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var url = $"{ReqresBaseUrl}/users/{userId}";
        var answer = await _rService.FetchAsync(url, _Headers, cancellationToken);
        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));
        return _rProcessor.FormatJsonAnswers(answer);
    }

    public async Task<string> Translate(string text)
    {
        var requestBody = new
        {
            q = text,
            source = "en",
            target = "ru",
            format = "text"
        };

        var jsonBody = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = _rService.FetchSync(TranslateBaseUrl, new Dictionary<string, string>
        {
            { "Content-Type", "application/json" }
        });

        if (_rProcessor.Error(response))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(response));

        var jsonResponse = JsonDocument.Parse(response);
        return jsonResponse.RootElement.GetProperty("translatedText").GetString();
    }

    public async Task<string> CatGetFactsAsync(CancellationToken cancellationToken = default)
    {
        var url = $"{CatBaseUrl}/fact";
        var answer = await _rService.FetchAsync(url, _Headers, cancellationToken);
        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));

        var jsonResponse = JsonDocument.Parse(answer);
        var factText = jsonResponse.RootElement.GetProperty("fact").GetString();

        var formattedJson = JsonSerializer.Serialize(new { fact = factText }, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        return formattedJson;
    }

    public async Task<string> JsonGetPostAsync(int postId, CancellationToken cancellationToken = default)
    {
        var url = $"{JsonBaseUrl}/posts/{postId}";
        var answer = await _rService.FetchAsync(url, _Headers, cancellationToken);
        if (_rProcessor.Error(answer))
            throw new Exception(_rProcessor.CocnlusionErrorMessage(answer));
        return _rProcessor.FormatJsonAnswers(answer);
    }

    public void Dispose()
    {
        _rService?.Dispose();
    }
}

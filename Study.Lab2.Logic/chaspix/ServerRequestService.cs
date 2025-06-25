using Study.Lab2.Logic.chaspix.DtoModels;
using Study.Lab2.Logic.Interfaces.chaspix;
using System.Text.Json;

namespace Study.Lab2.Logic.chaspix;

public class ServerRequestService : IServerRequestService
{
    private readonly IRequestService _requestService;
    private readonly IResponseProcessor _responseProcessor;
    private readonly Random _random = new Random();
    private const string WeatherApiKey = "a4753f4456777129a29b170766c7738a";

    public ServerRequestService(IRequestService requestService, IResponseProcessor responseProcessor)
    {
        _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        _responseProcessor = responseProcessor ?? throw new ArgumentNullException(nameof(responseProcessor));
    }

    public string GetRandomPost()
    {
        var postId = _random.Next(1, 101);
        var url = $"https://jsonplaceholder.typicode.com/posts/{postId}";

        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        try
        {
            var post = JsonSerializer.Deserialize<PostDto>(response);
            var formattedPost = new
            {
                DataType = "📝 Blog Post",
                AuthorId = post.UserId,
                PostId = post.Id,
                Title = post.Title,
                Content = post.Body.Length > 100 ? post.Body.Substring(0, 100) + "..." : post.Body
            };

            return JsonSerializer.Serialize(formattedPost, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch
        {
            return _responseProcessor.FormatJsonResponse(response);
        }
    }

    public string GetWeatherInfo(string city)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=demo&units=metric&lang=ru&appid={WeatherApiKey}";

        try
        {
            var response = _requestService.FetchData(url);

            if (_responseProcessor.HasError(response))
                throw new Exception(_responseProcessor.ExtractErrorMessage(response));

            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            var weatherInfo = new
            {
                DataType = "🌤️ Weather Information",
                City = root.GetProperty("name").GetString(),
                Country = root.GetProperty("sys").GetProperty("country").GetString(),
                Temperature = $"{root.GetProperty("main").GetProperty("temp").GetDecimal():F1}°C",
                FeelsLike = $"{root.GetProperty("main").GetProperty("feels_like").GetDecimal():F1}°C",
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString(),
                Humidity = $"{root.GetProperty("main").GetProperty("humidity").GetInt32()}%",
                PressureHPa = root.GetProperty("main").GetProperty("pressure").GetInt32(), // Давление в гПа
                WindSpeed = $"{root.GetProperty("wind").GetProperty("speed").GetDecimal()} m/s"
            };

            return JsonSerializer.Serialize(weatherInfo, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (Exception)
        {
            var mockWeather = new
            {
                DataType = "🌤️ Weather Information (Demo Data)",
                City = city,
                Temperature = $"{_random.Next(-5, 25)}°C",
                Description = new[] { "clear", "cloudy", "rain", "snow" }[_random.Next(4)],
                Humidity = $"{_random.Next(30, 90)}%",
                Note = "Demo data due to API unavailability"
            };

            return JsonSerializer.Serialize(mockWeather, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
    }

    public string GetCatFact()
    {
        var url = "https://catfact.ninja/fact";

        var response = _requestService.FetchData(url);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        try
        {
            var catFact = JsonSerializer.Deserialize<CatFactDto>(response);
            var formattedFact = new
            {
                DataType = "🐱 Interesting Cat Fact",
                Fact = catFact.Fact,
                TextLength = catFact.Length,
                Category = "Amazing Animals"
            };

            return JsonSerializer.Serialize(formattedFact, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch
        {
            return _responseProcessor.FormatJsonResponse(response);
        }
    }

    public async Task<string> GetRandomPostAsync(CancellationToken cancellationToken = default)
    {
        var postId = _random.Next(1, 101);
        var url = $"https://jsonplaceholder.typicode.com/posts/{postId}";

        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        try
        {
            var post = JsonSerializer.Deserialize<PostDto>(response);
            var formattedPost = new
            {
                DataType = "📝 Blog Post (Async)",
                AuthorId = post.UserId,
                PostId = post.Id,
                Title = post.Title,
                Content = post.Body.Length > 100 ? post.Body.Substring(0, 100) + "..." : post.Body
            };

            return JsonSerializer.Serialize(formattedPost, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch
        {
            return _responseProcessor.FormatJsonResponse(response);
        }
    }

    public async Task<string> GetWeatherInfoAsync(string city, CancellationToken cancellationToken = default)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=demo&units=metric&lang=ru&appid={WeatherApiKey}";

        try
        {
            var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

            if (_responseProcessor.HasError(response))
                throw new Exception(_responseProcessor.ExtractErrorMessage(response));

            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            var weatherInfo = new
            {
                DataType = "🌤️ Weather Information (Async)",
                City = root.GetProperty("name").GetString(),
                Country = root.GetProperty("sys").GetProperty("country").GetString(),
                Temperature = $"{root.GetProperty("main").GetProperty("temp").GetDecimal():F1}°C",
                FeelsLike = $"{root.GetProperty("main").GetProperty("feels_like").GetDecimal():F1}°C",
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString(),
                Humidity = $"{root.GetProperty("main").GetProperty("humidity").GetInt32()}%",
                PressureHPa = root.GetProperty("main").GetProperty("pressure").GetInt32(),
                WindSpeed = $"{root.GetProperty("wind").GetProperty("speed").GetDecimal()} m/s"
            };

            return JsonSerializer.Serialize(weatherInfo, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception)
        {
            var mockWeather = new
            {
                DataType = "🌤️ Weather Information (Async, Demo Data)",
                City = city,
                Temperature = $"{_random.Next(-5, 25)}°C",
                Description = new[] { "clear", "cloudy", "rain", "snow" }[_random.Next(4)],
                Humidity = $"{_random.Next(30, 90)}%",
                Note = "Demo data due to API unavailability"
            };

            return JsonSerializer.Serialize(mockWeather, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
    }

    public async Task<string> GetCatFactAsync(CancellationToken cancellationToken = default)
    {
        var url = "https://catfact.ninja/fact";

        var response = await _requestService.FetchDataAsync(url, null, cancellationToken);

        if (_responseProcessor.HasError(response))
            throw new Exception(_responseProcessor.ExtractErrorMessage(response));

        try
        {
            var catFact = JsonSerializer.Deserialize<CatFactDto>(response);
            var formattedFact = new
            {
                DataType = "🐱 Interesting Cat Fact (Async)",
                Fact = catFact.Fact,
                TextLength = catFact.Length,
                Category = "Amazing Animals"
            };

            return JsonSerializer.Serialize(formattedFact, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch
        {
            return _responseProcessor.FormatJsonResponse(response);
        }
    }

    public void Dispose()
    {
        if (_requestService is IDisposable disposableRequestService)
        {
            disposableRequestService.Dispose();
        }
    }
}
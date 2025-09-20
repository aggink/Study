using System.Diagnostics;
using Study.Lab2.Logic.Interfaces.fableslots;

namespace Study.Lab2.Logic.fableslots;

public class fableslotsService : IRunService
{
    private readonly IRequestService _requestService;

    public fableslotsService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    public void RunTask()
    {
        Console.WriteLine("=================================================");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            // Запрос 1: Получение поста
            Console.WriteLine("\n1. Получение города:");
            var post = _requestService.FetchData("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Moscow");
            Console.WriteLine(post);

            // Запрос 2: Получение пользователя
            Console.WriteLine("\n2. Получение города:");
            var user = _requestService.FetchData("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Minsk");
            Console.WriteLine(user);

            // Запрос 3: Получение комментария
            Console.WriteLine("\n3. Получение города:");
            var comment = _requestService.FetchData("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Manchester");
            Console.WriteLine(comment);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении синхронных запросов: {ex.Message}");
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nОбщая длительность синхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("=================================================");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            // Асинхронный запрос 1: Получение поста
            Console.WriteLine("\n1. Асинхронное получение поста по городу 1:");
            var post = await _requestService.FetchDataAsync("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Moscow",
                cancellationToken);
            Console.WriteLine(post);

            // Асинхронный запрос 2: Получение пользователя
            Console.WriteLine("\n2. Асинхронное получение пользователя по городу 2:");
            var user = await _requestService.FetchDataAsync("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Minsk",
                cancellationToken);
            Console.WriteLine(user);

            // Асинхронный запрос 3: Получение комментария
            Console.WriteLine("\n3. Асинхронное получение комментария по городу 3:");
            var comment = await _requestService.FetchDataAsync("http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q=Manchester",
                cancellationToken);
            Console.WriteLine(comment);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Асинхронные запросы были отменены.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении асинхронных запросов: {ex.Message}");
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nОбщая длительность асинхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
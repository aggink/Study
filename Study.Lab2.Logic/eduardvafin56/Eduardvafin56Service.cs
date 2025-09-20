using System.Diagnostics;
using Study.Lab2.Logic.Interfaces.eduardvafin56;

namespace Study.Lab2.Logic.eduardvafin56;

public class Eduardvafin56Service : IRunService
{
    private readonly IRequestService _requestService;

    public Eduardvafin56Service()
    {
        _requestService = new RequestService(new HttpClient());
    }

    public void RunTask()
    {
        Console.WriteLine("=== Eduardvafin56Service - Синхронные запросы ===");
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            // Запрос 1: Получение поста
            Console.WriteLine("\n1. Получение поста по ID 1:");
            var post = _requestService.FetchData("https://jsonplaceholder.typicode.com/posts/1");
            Console.WriteLine(post);

            // Запрос 2: Получение пользователя
            Console.WriteLine("\n2. Получение пользователя по ID 1:");
            var user = _requestService.FetchData("https://jsonplaceholder.typicode.com/users/1");
            Console.WriteLine(user);

            // Запрос 3: Получение комментария
            Console.WriteLine("\n3. Получение комментария по ID 1:");
            var comment = _requestService.FetchData("https://jsonplaceholder.typicode.com/comments/1");
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
        Console.WriteLine("=== Eduardvafin56Service - Асинхронные запросы ===");
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            // Асинхронный запрос 1: Получение поста
            Console.WriteLine("\n1. Асинхронное получение поста по ID 1:");
            var post = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/posts/1",
                cancellationToken);
            Console.WriteLine(post);

            // Асинхронный запрос 2: Получение пользователя
            Console.WriteLine("\n2. Асинхронное получение пользователя по ID 1:");
            var user = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/users/1",
                cancellationToken);
            Console.WriteLine(user);

            // Асинхронный запрос 3: Получение комментария
            Console.WriteLine("\n3. Асинхронное получение комментария по ID 1:");
            var comment = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/comments/1",
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
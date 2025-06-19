using System.Diagnostics;
using Study.Lab2.Logic.Interfaces.baldfromazzers;

namespace Study.Lab2.Logic.baldfromazzers;

public class baldfromazzersService : IRunService
{
    private readonly IRequestService _requestService;

    public baldfromazzersService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    public void RunTask()
    {
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            Console.WriteLine("\n1. Получение поста по ID 22:");
            var post = _requestService.FetchData("https://jsonplaceholder.typicode.com/posts/22");
            Console.WriteLine(post);
            
            Console.WriteLine("\n2. Получение пользователя по ID 2:");
            var user = _requestService.FetchData("https://jsonplaceholder.typicode.com/users/2");
            Console.WriteLine(user);
            
            Console.WriteLine("\n3. Получение комментария по ID 22:");
            var comment = _requestService.FetchData("https://jsonplaceholder.typicode.com/comments/22");
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
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            Console.WriteLine("\n1. Асинхронное получение поста по ID 22:");
            var post = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/posts/22",
                cancellationToken);
            Console.WriteLine(post);


            Console.WriteLine("\n2. Асинхронное получение пользователя по ID 2:");
            var user = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/users/2",
                cancellationToken);
            Console.WriteLine(user);


            Console.WriteLine("\n3. Асинхронное получение комментария по ID 22:");
            var comment = await _requestService.FetchDataAsync("https://jsonplaceholder.typicode.com/comments/22",
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
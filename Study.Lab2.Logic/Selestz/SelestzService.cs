using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Selestz;
using System.Diagnostics;

namespace Study.Lab2.Logic.Selestz;

public class SelestzService : IRunService
{
    private readonly IServerRequestService _serverRequestService;

    public SelestzService()
    {
        IRequestService requestService = new RequestService(new HttpClient());
        IResponseProcessor responseProcessor = new ResponseProcessor();
        _serverRequestService = new ServerRequestService(requestService, responseProcessor);
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос (Selestz)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Запрос случайного пользователя...");
            Console.ResetColor();
            var user = _serverRequestService.GetRandomUser();
            Console.WriteLine(user);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Запрос случайного поста...");
            Console.ResetColor();
            var post = _serverRequestService.GetRandomPost();
            Console.WriteLine(post);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Запрос случайного todo...");
            Console.ResetColor();
            var todo = _serverRequestService.GetRandomTodo();
            Console.WriteLine(todo);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе синхронные ответы успешно получены!\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка синхронного запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность синхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос (Selestz)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Запуск асинхронных запросов...");
            Console.ResetColor();

            var userTask = _serverRequestService.GetRandomUserAsync(cancellationToken);
            var postTask = _serverRequestService.GetRandomPostAsync(cancellationToken);
            var todoTask = _serverRequestService.GetRandomTodoAsync(cancellationToken);

            await Task.WhenAll(userTask, postTask, todoTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе асинхронные ответы успешно получены!\n");
            Console.ResetColor();

            Console.WriteLine("Результат пользователя:");
            Console.WriteLine(await userTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат поста:");
            Console.WriteLine(await postTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат todo:");
            Console.WriteLine(await todoTask);
            Console.WriteLine(new string('-', 50));
        }
        catch (OperationCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nАсинхронная операция была отменена.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка асинхронного запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность асинхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public void Dispose()
    {
        _serverRequestService?.Dispose();
    }
}
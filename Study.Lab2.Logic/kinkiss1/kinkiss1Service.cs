using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.kinkiss1;
using System.Diagnostics;

namespace Study.Lab2.Logic.kinkiss1;

public class kinkiss1Service : IRunService
{
    private readonly IServerRequestService _serverRequestService;

    // Идентификаторы для запросов
    private const int JsonPlaceholderUserId = 3;
    private const int ReqResUserId = 3;
    private const int JsonPlaceholderPostId = 3;

    public kinkiss1Service()
    {
        IRequestService requestService = new RequestService(new HttpClient());
        IResponseProcessor responseProcessor = new ResponseProcessor();
        _serverRequestService = new ServerRequestService(requestService, responseProcessor);
    }

    public void RunTask()
    {
        Console.WriteLine("\nСинхронный запрос (kinkiss1)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Запрос пользователя Placeholder (ID: {JsonPlaceholderUserId})...");
            Console.ResetColor();
            var jsonPlaceholderUser = _serverRequestService.JsonGetUser(JsonPlaceholderUserId);
            Console.WriteLine(jsonPlaceholderUser);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Запрос пользователя ReqRes (ID: {ReqResUserId})...");
            Console.ResetColor();
            var reqResUser = _serverRequestService.ReqresGetUser(ReqResUserId);
            Console.WriteLine(reqResUser);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Запрос фактов о кошках...");
            Console.ResetColor();
            var catFacts = _serverRequestService.CatGetFacts();
            Console.WriteLine(catFacts);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Запрос поста Placeholder (ID: {JsonPlaceholderPostId})...");
            Console.ResetColor();
            var jsonPlaceholderPost = _serverRequestService.JsonGetPost(JsonPlaceholderPostId);
            Console.WriteLine(jsonPlaceholderPost);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\nОбщая длительность синхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nАсинхронный запрос (kinkiss1)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Запуск асинхронных запросов...");
            Console.ResetColor();

            var jsonPlaceholderUserTask =
                _serverRequestService.JsonGetUserAsync(JsonPlaceholderUserId, cancellationToken);
            Console.WriteLine($"- Запрос пользователя Placeholder (ID: {JsonPlaceholderUserId}) запущен.");

            var reqResUserTask = _serverRequestService.ReqresGetUserAsync(ReqResUserId, cancellationToken);
            Console.WriteLine($"- Запрос пользователя ReqRes (ID: {ReqResUserId}) запущен.");

            var catFactsTask = _serverRequestService.CatGetFactsAsync(cancellationToken);
            var catFacts = await catFactsTask;
            Console.WriteLine("Факты о кошках:");
            Console.WriteLine(catFacts);
            Console.WriteLine(new string('-', 50));

            var jsonPlaceholderPostTask =
                _serverRequestService.JsonGetPostAsync(JsonPlaceholderPostId, cancellationToken);
            Console.WriteLine($"- Запрос поста Placeholder (ID: {JsonPlaceholderPostId}) запущен.");

            // Ожидаем завершения всех задач
            await Task.WhenAll(jsonPlaceholderUserTask, reqResUserTask, jsonPlaceholderPostTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе асинхронные ответы успешно получены!\n");
            Console.ResetColor();

            // Выводим результаты
            Console.WriteLine("Результат пользователя Placeholder:");
            Console.WriteLine(await jsonPlaceholderUserTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Факты о кошках:");
            Console.WriteLine(catFacts);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат пользователя ReqRes:");
            Console.WriteLine(await reqResUserTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат поста laceholder:");
            Console.WriteLine(await jsonPlaceholderPostTask);
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\nОбщая длительность асинхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public void Dispose()
    {
        _serverRequestService?.Dispose();
        GC.SuppressFinalize(this);
    }
}

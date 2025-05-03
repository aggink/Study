using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.xynthh;
using System.Diagnostics;

namespace Study.Lab2.Logic.xynthh;

public class XynthhService : IRunService
{
    private readonly IServerRequestService _serverRequestService;

    // Идентификаторы для запросов
    private const int JsonPlaceholderUserId = 1;
    private const int ReqResUserId          = 2;
    private const int JsonPlaceholderPostId = 3;

    public XynthhService()
    {
        IRequestService requestService = new RequestService(new HttpClient());
        IResponseProcessor responseProcessor = new ResponseProcessor();
        _serverRequestService = new ServerRequestService(requestService, responseProcessor);
    }

    public void RunTask()
    {
        Console.WriteLine("\nВыполняется синхронный запрос (xynthh)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Запрос пользователя JSONPlaceholder (ID: {JsonPlaceholderUserId})...");
            Console.ResetColor();
            var jsonPlaceholderUser = _serverRequestService.GetJsonPlaceholderUser(JsonPlaceholderUserId);
            Console.WriteLine(jsonPlaceholderUser);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Запрос пользователя ReqRes (ID: {ReqResUserId})...");
            Console.ResetColor();
            var reqResUser = _serverRequestService.GetReqResUser(ReqResUserId);
            Console.WriteLine(reqResUser);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Запрос поста JSONPlaceholder (ID: {JsonPlaceholderPostId})...");
            Console.ResetColor();
            var jsonPlaceholderPost = _serverRequestService.GetJsonPlaceholderPost(JsonPlaceholderPostId);
            Console.WriteLine(jsonPlaceholderPost);
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
        Console.WriteLine("\nВыполняется асинхронный запрос (xynthh)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Запуск асинхронных запросов...");
            Console.ResetColor();

            var jsonPlaceholderUserTask =
                _serverRequestService.GetJsonPlaceholderUserAsync(JsonPlaceholderUserId, cancellationToken);
            Console.WriteLine($"- Запрос пользователя JSONPlaceholder (ID: {JsonPlaceholderUserId}) запущен.");

            var reqResUserTask = _serverRequestService.GetReqResUserAsync(ReqResUserId, cancellationToken);
            Console.WriteLine($"- Запрос пользователя ReqRes (ID: {ReqResUserId}) запущен.");

            var jsonPlaceholderPostTask =
                _serverRequestService.GetJsonPlaceholderPostAsync(JsonPlaceholderPostId, cancellationToken);
            Console.WriteLine($"- Запрос поста JSONPlaceholder (ID: {JsonPlaceholderPostId}) запущен.");

            // Ожидаем завершения всех задач
            await Task.WhenAll(jsonPlaceholderUserTask, reqResUserTask, jsonPlaceholderPostTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе асинхронные ответы успешно получены!\n");
            Console.ResetColor();

            // Выводим результаты
            Console.WriteLine("Результат пользователя JSONPlaceholder:");
            Console.WriteLine(await jsonPlaceholderUserTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат пользователя ReqRes:");
            Console.WriteLine(await reqResUserTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Результат поста JSONPlaceholder:");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность асинхронного выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public void Dispose()
    {
        // Освобождаем ресурсы ServerRequestService, который в свою очередь освободит RequestService и HttpClient
        _serverRequestService?.Dispose();
        GC.SuppressFinalize(this);
    }
}
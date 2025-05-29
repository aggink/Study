using System.Diagnostics;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class kinkiss1Service : IRunService
{
    private readonly IServerRequestService _serverRequestService;

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
            Console.WriteLine($"Запрос фактов о кошках...");
            Console.ResetColor();

            var catFacts = _serverRequestService.CatGetFacts();
            Console.WriteLine(catFacts);
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Запрос цитаты Канье...");
            Console.ResetColor();

            var KanyeC = _serverRequestService.KanyeRest();
            Console.WriteLine(KanyeC);
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

            // Запускаем все задачи
            var catFactsTask = _serverRequestService.CatGetFactsAsync(cancellationToken);
            Console.WriteLine("- Запрос фактов о кошках запущен.");

            var kanyeTask = _serverRequestService.KanyeRestAsync(cancellationToken);
            Console.WriteLine("- Запрос цитаты Канье запущен.");

            Console.WriteLine("\nОжидание завершения всех запросов...");

            // Дожидаемся выполнения всех задач
            await Task.WhenAll(catFactsTask, kanyeTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе асинхронные ответы успешно получены!");
            Console.ResetColor();

            // Теперь выводим результаты по очереди
            Console.WriteLine("\nФакты о кошках:");
            Console.WriteLine(await catFactsTask);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("\nЦитата Канье:");
            Console.WriteLine(await kanyeTask);
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
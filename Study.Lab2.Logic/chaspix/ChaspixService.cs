using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.chaspix;
using System.Diagnostics;

namespace Study.Lab2.Logic.chaspix;

public class ChaspixService : IRunService
{
    private readonly IServerRequestService _serverRequestService;

    public ChaspixService()
    {
        IRequestService requestService = new RequestService(new HttpClient());
        IResponseProcessor responseProcessor = new ResponseProcessor();
        _serverRequestService = new ServerRequestService(requestService, responseProcessor);
    }

    public void RunTask()
    {
        Console.WriteLine("\n🔄 Выполняется синхронный запрос (Chaspix)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<(string Title, string Data, ConsoleColor Color)>();

            // Запрос 1: Случайный пост
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📝 Запрос 1: Получение случайного поста...");
            Console.ResetColor();
            var post = _serverRequestService.GetRandomPost();
            responses.Add(("СЛУЧАЙНЫЙ ПОСТ ИЗ БЛОГА", post, ConsoleColor.Blue));

            // Запрос 2: Погода
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🌤️ Запрос 2: Получение информации о погоде...");
            Console.ResetColor();
            var weather = _serverRequestService.GetWeatherInfo("Moscow");
            responses.Add(("ИНФОРМАЦИЯ О ПОГОДЕ В МОСКВЕ", weather, ConsoleColor.Yellow));

            // Запрос 3: Факт о кошках
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🐱 Запрос 3: Получение интересного факта о кошках...");
            Console.ResetColor();
            var catFact = _serverRequestService.GetCatFact();
            responses.Add(("ИНТЕРЕСНЫЙ ФАКТ О КОШКАХ", catFact, ConsoleColor.Magenta));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Все синхронные запросы успешно выполнены!\n");
            Console.ResetColor();

            DisplayResponses(responses);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Ошибка при выполнении синхронного запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n⏱️ Время выполнения синхронного метода: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\n🚀 Выполняется асинхронный запрос (Chaspix)...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🔄 Запуск асинхронных запросов...");
            Console.ResetColor();

            // Запускаем все задачи параллельно
            var postTask = _serverRequestService.GetRandomPostAsync(cancellationToken);
            Console.WriteLine("📝 - Запрос поста запущен");

            var weatherTask = _serverRequestService.GetWeatherInfoAsync("Saint Petersburg", cancellationToken);
            Console.WriteLine("🌤️ - Запрос погоды запущен");

            var catFactTask = _serverRequestService.GetCatFactAsync(cancellationToken);
            Console.WriteLine("🐱 - Запрос факта о кошках запущен");

            Console.WriteLine("\n⏳ Ожидание завершения всех запросов...");

            // Ждем завершения всех задач
            await Task.WhenAll(postTask, weatherTask, catFactTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Все асинхронные запросы успешно выполнены!\n");
            Console.ResetColor();

            var responses = new List<(string Title, string Data, ConsoleColor Color)>
            {
                ("СЛУЧАЙНЫЙ ПОСТ ИЗ БЛОГА (ASYNC)", await postTask, ConsoleColor.Blue),
                ("ИНФОРМАЦИЯ О ПОГОДЕ В СПБ (ASYNC)", await weatherTask, ConsoleColor.Yellow),
                ("ИНТЕРЕСНЫЙ ФАКТ О КОШКАХ (ASYNC)", await catFactTask, ConsoleColor.Magenta)
            };

            DisplayResponses(responses);
        }
        catch (OperationCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n🛑 Выполнение асинхронных запросов было отменено.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Ошибка при выполнении асинхронного запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n⏱️ Время выполнения асинхронного метода: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    private void DisplayResponses(List<(string Title, string Data, ConsoleColor Color)> responses)
    {
        foreach (var (title, data, color) in responses)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n═══ {title} ═══");
            Console.ResetColor();
            Console.WriteLine(data);
            Console.WriteLine(new string('─', 60));
        }
    }

    public void Dispose()
    {
        _serverRequestService?.Dispose();
    }
}
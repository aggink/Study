using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.cocobara;
using System.Diagnostics;

namespace Study.Lab2.Logic.cocobara;

public class cocobaraService : IRunService
{
    private readonly IRequestService _requestService;

    public cocobaraService()
    {
        _requestService = new RequestService(new HttpClient());

    }

    private string[] Urls = new string[3];

    public void RunTask()
    {
        Console.WriteLine("Сформируйте корректные запросы к различным астрологическим и мотивационным API\n");

        GetFirstRequest();
        GetSecondRequest();
        GetThreeRequest();

        Console.WriteLine("\nВыполняется синхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");

                var response = _requestService.FetchData(Urls[i]);
                responses.Add(response);
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            int index_response = 1;

            foreach (var response in responses)
            {
                Console.WriteLine($"\nРезультат запроса №{index_response}\n");
                Console.WriteLine(System.Text.RegularExpressions.Regex.Unescape(response));

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n" + new string('-', 100));
                Console.ResetColor();

                index_response++;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var tasks = new Task<string>[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Запрос {i + 1}: {Urls[i]}");

                tasks[i] = _requestService.FetchDataAsync(Urls[i], cancellationToken);
            }

            var responses = await Task.WhenAll(tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();

            int index_response = 1;

            foreach (var response in responses)
            {
                Console.WriteLine($"\nРезультат запроса №{index_response}\n");
                Console.WriteLine(System.Text.RegularExpressions.Regex.Unescape(response));

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n" + new string('-', 100));
                Console.ResetColor();

                index_response++;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    public void Dispose()
    {
        _requestService.Dispose();
    }

    private void GetFirstRequest()
    {
        Console.WriteLine("Horoscope API\nБесплатный API для получения ежедневного гороскопа по знаку зодиака (https://ohmanda.com/api/horoscope/).\n");

        Console.WriteLine("Введите ваш знак зодиака (на английском, например, aries, leo, taurus): ");
        string sign = Console.ReadLine();

        Urls[0] = $"https://ohmanda.com/api/horoscope/{sign.ToLower()}/";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }

    private void GetSecondRequest()
    {
        Console.WriteLine("\nMoon Phase API\nAPI для определения фазы Луны на выбранную дату (https://api.farmsense.net/v1/moonphases/).\n");
        Console.WriteLine("Введите дату в формате YYYY-MM-DD: ");
        string dateString = Console.ReadLine();

        DateTime date;
        if (!DateTime.TryParse(dateString, out date))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Дата введена неверно! Использую текущую дату.");
            Console.ResetColor();
            date = DateTime.UtcNow;
        }
        DateTimeOffset dateTimeOffset = new DateTimeOffset(date, TimeSpan.Zero);
        long unixTime = dateTimeOffset.ToUnixTimeSeconds();

        Urls[1] = $"https://api.farmsense.net/v1/moonphases/?d={unixTime}";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }

    private void GetThreeRequest()
    {
        Console.WriteLine("\nNASA APOD API\nAPI для получения астрономической картинки дня от NASA (https://api.nasa.gov/planetary/apod).\n");

        Urls[2] = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }
}

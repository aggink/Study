using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.brnvika;
using System.Diagnostics;

namespace Study.Lab2.Logic.brnvika;

public class brnvikaService : IRunService
{
    private readonly IRequestService _requestService;

    public brnvikaService()
    {
        _requestService = new RequestService(new HttpClient());
    }

    private string[] Urls = new string[3];

    public void RunTask()
    {
        Console.WriteLine("Сформируйте корректные запросы к различным API\n");

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
                Console.WriteLine("\nРезультат запроса №" + index_response.ToString() + "\n");
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
                Console.WriteLine("\nРезультат запроса №" + index_response.ToString() + "\n");
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
        Console.WriteLine("WeatherAPI\nWeatherAPI — сервис для получения данных о погоде, который предоставляет доступ к информации о текущей погоде, прогнозах, исторических данных и многому другому.\n");

        Console.WriteLine("Введите название города: ");
        string location = Console.ReadLine();

        Urls[0] = string.Format("http://api.weatherapi.com/v1/current.json?key=88770810754346f699491514250305&q={0}", location);

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }

    private void GetSecondRequest()
    {
        Console.WriteLine("\nAPI NASA\nAPOD - это один из API, который используется для получения изображений с портала НАСА. APOD расшифровывается как \"Астрономическая картинка дня\".");

        Console.WriteLine("Введите дату\n");

        Console.WriteLine("Год: ");
        string year = Console.ReadLine();

        Console.WriteLine("Месяц: ");
        string month = Console.ReadLine();

        Console.WriteLine("День: ");
        string day = Console.ReadLine();

        Urls[1] = string.Format("https://api.nasa.gov/planetary/apod?api_key=mIqheAgtIaufWvsTJuGyPbb27O3oCCRtFDikN3eH&date={0}-{1}-{2}", year, month, day);

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }

    private void GetThreeRequest()
    {
        Console.WriteLine("\nAPI Hipolabs\nHipolabs - API для поиска информации об университетах всего мира (данные на английском языке).\n");

        Console.WriteLine("Введите название страны: ");
        string country = Console.ReadLine();

        Console.WriteLine("Введите название университета: ");
        string university = Console.ReadLine();

        Urls[2] = string.Format("http://universities.hipolabs.com/search?country={0}&name={1}", country, university);

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("\n" + new string('-', 100));
        Console.ResetColor();
    }
}

using System.Diagnostics;
using System.Text.Json;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.danaky1;
using Study.Lab2.Logic.danaky1.DtoModels;

namespace Study.Lab2.Logic.danaky1;

public class danaky1Service : IRunService
{
    private readonly List<string> _localFacts = new()
    {
        "Россия - самая большая страна в мире (17.1 млн км²)",
        "Столица России - Москва (12.6 млн жителей)",
        "Озеро Байкал - самое глубокое в мире (1642 м)",
        "В России 11 часовых поясов",
        "Метро Санкт-Петербурга - самое глубокое в мире"
    };

    private const string _apiEndpoint = "https://restcountries.com/v3.1/name/russia";

    private readonly IRequestService _requestService;

    public danaky1Service()
    {
        _requestService = new RequestService(new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(5)
        });
    }

    public void RunTask()
    {
        Console.WriteLine("\nСинхронное выполнение (без async/await)\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.WriteLine("Попытка получить данные о России...");
            var response = _requestService.FetchData(_apiEndpoint);
            DisplayCountryInfo(response);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ResetColor();
            DisplayLocalFact();
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nАсинхронное выполнение (с async/await)\n");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Console.WriteLine("Попытка получить данные о России...");
            var response = await _requestService.FetchDataAsync(_apiEndpoint, cancellationToken);
            DisplayCountryInfo(response);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ResetColor();
            DisplayLocalFact();
        }
        finally
        {
            stopwatch.Stop();
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    private void DisplayCountryInfo(string jsonResponse)
    {
        try
        {
            var countries = JsonSerializer.Deserialize<List<CountryInfoDto>>(jsonResponse);
            var russia = countries?.FirstOrDefault();

            if (russia != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nДанные о России:");
                Console.ResetColor();

                Console.WriteLine($"Официальное название: {russia.Name.Official}");
                Console.WriteLine($"Столица: {string.Join(", ", russia.Capital)}");
                Console.WriteLine($"Население: {russia.Population:N0} человек");
                Console.WriteLine($"Площадь: {russia.Area:N0} км²");
                Console.WriteLine($"Континент: {string.Join(", ", russia.Continents)}");

                // Добавляем случайный локальный факт для дополнительной информации
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nИнтересный факт: {_localFacts[new Random().Next(_localFacts.Count)]}");
                Console.ResetColor();
            }
            else
            {
                throw new Exception("Данные о России не найдены");
            }
        }
        catch (JsonException ex)
        {
            throw new Exception($"Ошибка обработки JSON: {ex.Message}");
        }
    }

    private void DisplayLocalFact()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nИспользуются локальные данные:");
        Console.ResetColor();
        Console.WriteLine(_localFacts[new Random().Next(_localFacts.Count)]);
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
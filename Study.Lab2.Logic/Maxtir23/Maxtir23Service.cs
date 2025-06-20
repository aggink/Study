﻿using Study.Lab2.Logic.Maxtir23.DtoModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Maxtir23;

namespace Study.Lab2.Logic.Maxtir23;

public class Maxtir23Service : IRunService, IDisposable
{
    private readonly string[] urls = new[]
    {
            "https://petstore.swagger.io/v2/user/Andrew23",
            "https://petstore.swagger.io/v2/user/Valera23"
    };

    private readonly IRequestService _requestService;

    public Maxtir23Service() : this(new RequestService(new HttpClient())) { }

    public Maxtir23Service(IRequestService requestService)
    {
        _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
    }

    public void RunTask()
    {
        RunInternal(async: false);
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        await RunInternalAsync(cancellationToken);
    }

    private void RunInternal(bool async)
    {
        Console.WriteLine("\nВыполняется {0} запрос...\n", async ? "асинхронный" : "синхронный");
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Было отправлено {0} запроса к Petstore API", urls.Length);
            Console.ResetColor();

            foreach (var url in urls)
            {
                try
                {
                    var response = async
                        ? _requestService.FetchDataAsync(url).GetAwaiter().GetResult()
                        : _requestService.FetchData(url);
                    responses.Add(response);
                }
                catch (Exception ex)
                {
                    responses.Add($"Error: {ex.Message}");
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nВсе запросы завершены!\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nКритическая ошибка: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            ProcessResponses(responses);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    private async Task RunInternalAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("\nВыполняется асинхронный запрос...\n");
        var stopwatch = Stopwatch.StartNew();
        var responses = new List<string>();

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Было отправлено {0} запроса к Petstore API", urls.Length);
            Console.ResetColor();

            var tasks = urls.Select(url =>
                _requestService.FetchDataAsync(url, cancellationToken)).ToList();

            var results = await Task.WhenAll(tasks);
            responses.AddRange(results);


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nВсе ответы успешно получены!\n");
            Console.ResetColor();
        }
        catch (OperationCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nОперация была отменена");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nОшибка запроса: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            stopwatch.Stop();
            ProcessResponses(responses);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
            Console.ResetColor();
        }
    }

    private void ProcessResponses(List<string> responses)
    {
        Console.WriteLine("Обработка ответов:");
        Console.WriteLine(new string('-', 40));

        int counter = 1;
        foreach (var response in responses)
        {
            if (response.StartsWith("Error:"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Ответ #{counter}: {response}");
                Console.ResetColor();
            }
            else
            {
                try
                {
                    var user = JsonSerializer.Deserialize<RecipeDTO.Root>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        WriteIndented = true
                    });

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Пользователь #{counter}:");
                    Console.ResetColor();

                    string prettyJson = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(prettyJson);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Ошибка десериализации ответа #{counter}: {ex.Message}");
                    Console.ResetColor();
                }
            }
            counter++;
            Console.WriteLine(new string('-', 40));
        }
    }

    public void Dispose()
    {
        _requestService?.Dispose();
        GC.SuppressFinalize(this);
    }
}


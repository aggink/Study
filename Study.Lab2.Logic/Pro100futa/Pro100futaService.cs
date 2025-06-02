using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Pro100futa;
using Study.Lab2.Logic.Pro100futa.DtoModels;
using System.Diagnostics;
using System.Text.Json;

namespace Study.Lab2.Logic.Pro100futa;
//хихихаха
public class Pro100futaService : IRunService
{
	private readonly IRequestService _requestService;

	private readonly string url = "https://official-joke-api.appspot.com/jokes/random";

	public Pro100futaService()
	{
		_requestService = new RequestService(new HttpClient());
	}

	public void RunTask()
	{
		Console.WriteLine("\nВыполняется синхронный запрос...\n");
		var stopwatch = Stopwatch.StartNew();
		var responses = new List<string>();

		try
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"Было отправлено 3 запроса к: {url}");
			Console.ResetColor();
			for (int i = 0; i < 3; i++)
			{
				var response = _requestService.FetchData(url);
				responses.Add(response);
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nВсе ответы успешно получены!\n");
			Console.ResetColor();
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

			int counter = 1;

			foreach (var response in responses)
			{
				try
				{
					RandomJokesResponseDto RanJoke = JsonSerializer.Deserialize<RandomJokesResponseDto>(response);

					if (RanJoke.Data != null && RanJoke.Data.Count > 0)
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.WriteLine("Here's random joke number " + counter + " for today!");
						Console.ResetColor();
						Console.WriteLine(RanJoke.Data[0]);
						Console.WriteLine(new string('-', 100));
						counter++;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.WriteLine("No jokes for you today, sorry");
						Console.ResetColor();
					}
				}
				catch (JsonException ex)
				{
					Console.WriteLine($"JSON Error: {ex.Message}");
				}
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
			Console.ResetColor();
		}
	}

	public async Task RunTaskAsync(CancellationToken cancellationToken)
	{
		Console.WriteLine("\nВыполняется асинхронный запрос...\n");
		var stopwatch = Stopwatch.StartNew();
		var jsonResponses = new string[3];

		try
		{
			var tasks = new Task<string>[3];

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"Было отправлено 3 запроса к: {url}");
			Console.ResetColor();

			for (int i = 0; i < 3; i++)
			{
				tasks[i] = _requestService.FetchDataAsync(url, cancellationToken);
			}

			var responses = await Task.WhenAll(tasks);
			jsonResponses = responses;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nВсе ответы успешно получены!\n");
			Console.ResetColor();
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

			int counter = 1;

			foreach (var response in jsonResponses)
			{
				try
				{
					RandomJokesResponseDto RanJoke = JsonSerializer.Deserialize<RandomJokesResponseDto>(response);

					if (RanJoke.Data != null && RanJoke.Data.Count > 0)
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.WriteLine("Here's random joke number " + counter + " for today!");
						Console.ResetColor();
						Console.WriteLine(RanJoke.Data[0]);
						Console.WriteLine(new string('-', 100));
						counter++;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.WriteLine("No jokes for you today, sorry");
						Console.ResetColor();
					}
				}
				catch (JsonException ex)
				{
					Console.WriteLine($"JSON Error: {ex.Message}");
				}
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс");
			Console.ResetColor();
		}
	}

	public void Dispose()
	{
		_requestService.Dispose();
	}
}

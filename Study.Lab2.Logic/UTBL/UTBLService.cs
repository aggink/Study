using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.UTBL;
using System.Diagnostics;

namespace Study.Lab2.Logic.UTBL;

public class UTBLService : IRunService
{
    private readonly IRequestService _requestHandler;
    private string[] _apiUrls = new string[3];

    public UTBLService()
    {
        _requestHandler = new RequestService(new HttpClient());
        SetupApis(); // ��������� ������������� URL � �����������
    }

    public void RunTask()
    {
        Console.WriteLine("������������� ��������...\n");
        Console.WriteLine("\n����� ���������� ��������...\n");
        var timer = Stopwatch.StartNew();

        try
        {
            var responses = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"������ {i + 1}: {_apiUrls[i]}");
                responses.Add(_requestHandler.FetchData(_apiUrls[i]));
            }

            ShowSuccess(responses, timer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            ShowError($"������: {ex.Message}");
        }
        finally
        {
            timer.Stop();
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("\n������ ����������� ��������...\n");
        var timer = Stopwatch.StartNew();

        try
        {
            var tasks = _apiUrls.Select((url, index) =>
            {
                Console.WriteLine($"������ {index + 1}: {url}"); // ��������� ����� URL
                return _requestHandler.FetchDataAsync(url, cancellationToken);
            }).ToArray();

            var responses = await Task.WhenAll(tasks);
            ShowSuccess(responses, timer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            ShowError($"������: {ex.Message}");
        }
        finally
        {
            timer.Stop();
        }
    }

    private void SetupApis()
    {
        SetupWeatherApi();
        SetupNasaApi();
        SetupUniversityApi();
    }

    private void SetupWeatherApi()
    {
        Console.Write("WeatherAPI - ��������� ������ � ������� ������ � ��������� ������.\n\n");
        Console.Write("����� ��� ��������: ");
        string city = Console.ReadLine();
        _apiUrls[0] = $"http://api.weatherapi.com/v1/current.json?key=75723b4740b94a519bd114249251005&q={city}";
        PrintSeparator();
    }

    private void SetupNasaApi()
    {
        Console.Write("NASA APOD API - ��������� ��������������� �������� ���.\n\n");
        Console.Write("��� (****): ");
        string year = Console.ReadLine();
        Console.Write("����� (**): ");
        string month = Console.ReadLine();
        Console.Write("���� (**): ");
        string day = Console.ReadLine();
        _apiUrls[1] = $"https://api.nasa.gov/planetary/apod?api_key=WvVHdwoc2g3ZFW4vjIUucePQqPRLfaCKHn04eY4H&date={year}-{month}-{day}";
        PrintSeparator();
    }

    private void SetupUniversityApi()
    {
        Console.Write("Universities API (HipoLabs) - ����� ���������� �� ������������� �� ������ � ��������.\n\n");
        Console.Write("������: ");
        string country = Console.ReadLine();
        Console.Write("�����������: ");
        string name = Console.ReadLine();
        _apiUrls[2] = $"http://universities.hipolabs.com/search?country={country}&name={name}";
        PrintSeparator();
    }

    private void ShowSuccess(IEnumerable<string> responses, long time)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n��� ������ ��������!");
        Console.ResetColor();

        int counter = 1;
        foreach (var response in responses)
        {
            Console.WriteLine($"\n����� {counter}:\n{response}");
            PrintSeparator();
            counter++;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n����� ����������: {time} ��");
        Console.ResetColor();
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }

    private void PrintSeparator() =>
        Console.WriteLine("\n" + new string('~', 100));

    public void Dispose() => _requestHandler.Dispose();
}
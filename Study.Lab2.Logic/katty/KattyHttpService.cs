using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.katty;
using System.Diagnostics;

namespace Study.Lab2.Logic.katty;

public class KattyHttpService : IRunService
{
    private readonly IServerRequestService _serverRequestService;

    public KattyHttpService()
    {
        var requestService = new RequestService();
        var responseProcessor = new ResponseProcessor();
        _serverRequestService = new ServerRequestService(requestService, responseProcessor);
    }

    public void RunTask()
    {
        Console.WriteLine("Начало выполнения синхронных запросов...");
        try
        {
            var stopwatch = Stopwatch.StartNew();
            var (responses, serviceTime) = _serverRequestService.ExecuteRequests();
            stopwatch.Stop();

            foreach (var response in responses)
            {
                Console.WriteLine(response);
                Console.WriteLine();
            }

            Console.WriteLine("Все запросы выполнены успешно.");
            Console.WriteLine($"Время выполнения в сервисе: {serviceTime} мс");
            Console.WriteLine($"Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запросов: {ex.Message}");
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Начало выполнения асинхронных запросов...");
        try
        {
            var stopwatch = Stopwatch.StartNew();
            var (responses, serviceTime) = await _serverRequestService.ExecuteRequestsAsync(cancellationToken);
            stopwatch.Stop();

            foreach (var response in responses)
            {
                Console.WriteLine(response);
                Console.WriteLine();
            }

            Console.WriteLine("Все асинхронные запросы выполнены успешно.");
            Console.WriteLine($"Время выполнения в сервисе: {serviceTime} мс");
            Console.WriteLine($"Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Выполнение асинхронных запросов было отменено");
        }
        catch (Exception ex)
        {
            var actualException = ex.InnerException ?? ex;
            Console.WriteLine($"Произошла ошибка при выполнении асинхронных запросов: {actualException.Message}");
        }
    }

    public void Dispose() => _serverRequestService.Dispose();
}
using System.Text.Json;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.yamisakimei;
using Study.Lab2.Logic.yamisakimei.DtoModels;

namespace Study.Lab2.Logic.yamisakimei;

public class yamisakimeiService : IRunService
{
    private readonly IRequestService _requestService;

    public yamisakimeiService() : this(new RequestService(new HttpClient()))
    { }

    public yamisakimeiService(IRequestService requestService)
    {
        _requestService = requestService;
    }

    public void RunTask()
    {
        try
        {
            var users = _requestService.FetchData("/api/?results=3");
            DisplayUsers(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    public async Task RunTaskAsync(CancellationToken cancellationToken)
    {
        try
        {
            var users = await _requestService.FetchDataAsync("/api/?results=5", cancellationToken);
            DisplayUsers(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    private void DisplayUsers(string jsonResponse)
    {
        var usersData = JsonSerializer.Deserialize<UserResponse>(jsonResponse);

        if (usersData?.Results != null)
        {
            foreach (var user in usersData.Results)
            {
                Console.WriteLine($"\nИмя: {user.Name?.First} {user.Name?.Last}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Город: {user.Location?.City}, Страна: {user.Location?.Country}");
                Console.WriteLine($"Фото: {user.Picture?.Large}");
            }
        }
    }

    public void Dispose()
    {
        _requestService?.Dispose();
    }
}
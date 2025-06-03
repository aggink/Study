using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
    public InvalidInputException(string message, Exception ex) : base(message, ex) { }
}

public class Task14 : IRunnableAsync
{
    public async Task RunAsync()
    {
        try
        {
            Console.Write("Введите целое число: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректное число.");
                return;
            }

            var result = await CalculateAsync(n);

            Console.WriteLine($"Сумма квадратов от 1 до {n} = {result}");
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        }
    }

    private async Task<int> CalculateAsync(int n)
    {
        if (n <= 0)
            throw new InvalidInputException("n должно быть больше 0");

        var tasks = new Task<int>[]
        {
            Task.Run(async () =>
            {
                await Task.Delay(1000);

                return 1;
            }),

            Task.Run(async () =>
            {
                await Task.Delay(1000);

               return 2;
            }),

            Task.Run(async () =>
            {
                await Task.Delay(1000);

                return 3;
            })
        };

        int[] results = await Task.WhenAll(tasks);

        return results[0] + results[1] + results[2];
    }
}

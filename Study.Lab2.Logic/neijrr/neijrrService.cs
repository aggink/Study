using System.Diagnostics;
using Study.Lab2.Logic.Interfaces.neijrr;
using Study.Lab2.Logic.Interfaces;

namespace Study.Lab2.Logic.neijrr
{
    public class neijrrService(IServerRequestService serverRequestService = null) : IRunService
    {
        private readonly IServerRequestService _serverRequestService = serverRequestService ?? new ServerRequestService(
            "https://jsonplaceholder.typicode.com/"
        );

        private readonly Random rnd = new();

        public void RunTask()
        {
            Console.WriteLine("\nВыполняется синхронный запрос...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                #region Request 1
                var id = rnd.Next(0, 100);
                ColoredConsole.WriteLine($"Запрос 1: Получение поста {id}", ConsoleColor.Cyan);
                IPost post = _serverRequestService.GetPost(id);

                ColoredConsole.WriteLine("\nПост:", ConsoleColor.Green);
                Console.WriteLine(post);
                Console.WriteLine();
                #endregion

                #region Request 2
                var userId = rnd.Next(0, 10);
                ColoredConsole.WriteLine($"Запрос 2: Создание поста пользователем {userId}", ConsoleColor.Cyan);
                int postId = _serverRequestService.SendPost(id, "This is test post", "The quick brown fox jumps over the lazy dog.");

                ColoredConsole.WriteLine("\nID поста:", ConsoleColor.Green);
                Console.WriteLine(postId);
                Console.WriteLine();
                #endregion

                #region Request 3
                ColoredConsole.WriteLine($"Запрос 3: Обновление поста {id}", ConsoleColor.Cyan);
                post = _serverRequestService.UpdatePost(id, body: "This is edited post");

                ColoredConsole.WriteLine("\nОтвет сервера:", ConsoleColor.Green);
                Console.WriteLine(post);
                Console.WriteLine();
                #endregion
            }
            catch (Exception ex)
            {
                ColoredConsole.WriteLine($"\nОшибка запроса: {ex.Message}", ConsoleColor.Red);
            }
            finally
            {
                stopwatch.Stop();
                ColoredConsole.WriteLine(
                    $"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс", ConsoleColor.Yellow
                );
            }
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("\nВыполняется асинхронный запрос...\n");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var id = rnd.Next(0, 100);
                var userId = rnd.Next(0, 10);

                var postTask = _serverRequestService.GetPostAsync(id, cancellationToken);
                ColoredConsole.WriteLine($"Запущен запрос 1: Получение поста {id}", ConsoleColor.Cyan);

                var newPostTask = _serverRequestService.SendPostAsync(id, "This is test post", "The quick brown fox jumps over the lazy dog.", cancellationToken);
                ColoredConsole.WriteLine($"Запущен запрос 2: Создание поста пользователем {userId}", ConsoleColor.Cyan);

                var deletedPostTask = _serverRequestService.UpdatePostAsync(id, body: "This is edited post", cancellationToken: cancellationToken);
                ColoredConsole.WriteLine($"Запущен запрос 3: Обновление поста {id}", ConsoleColor.Cyan);

                await Task.WhenAll(postTask, newPostTask, deletedPostTask);

                ColoredConsole.WriteLine("\nВсе асинхронные ответы успешно получены!\n", ConsoleColor.Green);

                Console.WriteLine("Результат запроса 1:");
                Console.WriteLine(await postTask);
                Console.WriteLine();

                Console.WriteLine("Результат запроса 2:");
                Console.WriteLine(await newPostTask);
                Console.WriteLine();

                Console.WriteLine("Результат запроса 3:");
                Console.WriteLine(await deletedPostTask);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                ColoredConsole.WriteLine($"\nОшибка запроса: {ex.Message}", ConsoleColor.Red);
            }
            finally
            {
                stopwatch.Stop();
                ColoredConsole.WriteLine(
                    $"\nОбщая длительность: {stopwatch.ElapsedMilliseconds} мс", ConsoleColor.Yellow
                );
            }
        }

        public void Dispose()
        {
            _serverRequestService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

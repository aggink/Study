using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.Kotsutaki;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;



namespace Study.Lab2.Logic.Kotsutaki;

public class KotsutakiService : IRunService
{
        private readonly IRequestService _requestService;

        public KotsutakiService()
        {
            _requestService = new RequestService(new HttpClient());
        }

        private const string Url = "https://stathamcitaty.ru/";

        public void RunTask()
        {
            Console.WriteLine("\nСинхронный запрос цитаты Statham...\n");
            var sw = Stopwatch.StartNew();
            try
            {
                var html = _requestService.FetchData(Url);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Цитата Джейсона Стэйтема:");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                sw.Stop();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nВремя выполнения: {sw.ElapsedMilliseconds} мс\n");
                Console.ResetColor();
            }
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("\nАсинхронный запрос цитаты Statham...\n");
            var sw = Stopwatch.StartNew();
            try
            {
                var html = _requestService.FetchData(Url);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Цитата Джейсона Стэйтема:");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                sw.Stop();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nВремя выполнения: {sw.ElapsedMilliseconds} мс\n");
                Console.ResetColor();
            }
        }

        // Простой парсер: ищет последний блок цитаты на странице
        

        public void Dispose()
        {
            _requestService.Dispose();
        }
}
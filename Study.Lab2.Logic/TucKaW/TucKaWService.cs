using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Study.Lab2.Logic.Interfaces;
using Study.Lab2.Logic.Interfaces.TucKaW;
using Study.Lab2.Logic.TucKaW.DtoModels;

namespace Study.Lab2.Logic.TucKaW
{
    public class TucKaWService : IRunService
    {
        private readonly IRequestService _requestService;
        private readonly List<string> _localFacts = new()
        {
            "🔵🔴 ФК Барселона - один из самых титулованных клубов мира",
            "🏆 26 раз чемпион Испании, 5 раз победитель Лиги Чемпионов",
            "⭐ Легендарные игроки: Месси, Кройф, Марадона, Хави, Иньеста",
            "🏟 Камп Ноу - крупнейший стадион Европы (99 354 места)",
            "👕 Клубные цвета: синий и гранатовый (blaugrana)"
        };

        public TucKaWService()
        {
            var httpClient = new HttpClient();
            // Добавляем заголовки для избежания 403 Forbidden
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BarcaFactsApp/1.0");
            _requestService = new RequestService(httpClient);
        }

        public void RunTask()
        {
            Console.WriteLine("\n=== СИНХРОННЫЙ ЗАПРОС ===\n");
            ProcessRequest(false).Wait();
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("\n=== АСИНХРОННЫЙ ЗАПРОС ===\n");
            await ProcessRequest(true, cancellationToken);
        }

        private async Task ProcessRequest(bool asyncMode, CancellationToken ct = default)
        {
            var timer = Stopwatch.StartNew();

            try
            {
                // Всегда используем локальные данные, так как API требует ключ
                var barcaData = BarcaFactResponseDto.CreateDefault();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== ИНФОРМАЦИЯ О ФК БАРСЕЛОНА ===\n");
                Console.ResetColor();

                foreach (var fact in barcaData.Data)
                {
                    Console.WriteLine($"✅ {fact}");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n🔍 ДОПОЛНИТЕЛЬНЫЕ ФАКТЫ:");
                Console.ResetColor();

                foreach (var fact in _localFacts)
                {
                    Console.WriteLine($"✨ {fact}");
                    if (asyncMode) await Task.Delay(200, ct); // Анимация для асинхронного режима
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⚠ Ошибка: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                timer.Stop();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n⏱ Время выполнения: {timer.ElapsedMilliseconds} мс");
                Console.ResetColor();
            }
        }

        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }
}
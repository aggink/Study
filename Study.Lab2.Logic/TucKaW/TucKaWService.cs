﻿using System;
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
        private const string ApiUrl = "https://api.football-data.org/v4/teams/81";
        private readonly List<string> _defaultFacts = new()
        {
            "🔵🔴 ФК Барселона основана 29 ноября 1899 года",
            "🏟 Камп Ноу - крупнейший стадион Европы (99 354 места)",
            "⭐ Легендарные игроки: Месси, Кройф, Марадона",
            "🏆 26-кратный чемпион Испании, 5-кратный победитель ЛЧ",
            "👕 Клубные цвета: синий и гранатовый (blaugrana)",
            "🎯 Девиз: «Més que un club» (Больше, чем клуб)"
        };

        private readonly IRequestService _requestService;

        public TucKaWService()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("1f8524f08bb54ab0b68e256c6d1b98f9", "1f8524f08bb54ab0b68e78ttyp");
            _requestService = new RequestService(httpClient);
        }

        public TucKaWService(IRequestService requestService)
        {
            _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
        }

        public void RunTask()
        {
            ProcessFootballData(false).Wait();
        }

        public async Task RunTaskAsync(CancellationToken cancellationToken)
        {
            await ProcessFootballData(true, cancellationToken);
        }

        private async Task ProcessFootballData(bool asyncMode, CancellationToken ct = default)
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine("\n=== ЗАПРОС ДАННЫХ О ФК БАРСЕЛОНА ===\n");

            try
            {
                string json = asyncMode
                    ? await _requestService.FetchDataAsync(ApiUrl, ct)
                    : _requestService.FetchData(ApiUrl);

                var data = JsonSerializer.Deserialize<BarcaFactResponseDto>(json);
                DisplayFootballInfo(data ?? BarcaFactResponseHelper.CreateDefault());
            }
            catch (Exception ex)
            {
                HandleError(ex);
                DisplayFootballInfo(BarcaFactResponseHelper.CreateDefault());
            }
            finally
            {
                stopwatch.Stop();
                DisplayExecutionTime(stopwatch.ElapsedMilliseconds);
            }
        }

        private void DisplayFootballInfo(BarcaFactResponseDto data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("📌 ОСНОВНАЯ ИНФОРМАЦИЯ:");
            Console.ResetColor();

            foreach (var fact in data.Data)
            {
                Console.WriteLine($"  • {fact}");
                Thread.Sleep(100);
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n🌟 ИСТОРИЧЕСКИЕ ДОСТИЖЕНИЯ:");
            Console.ResetColor();
            Console.WriteLine("  • Первый клуб, выигравший 6 трофеев за год (2009)");
            Console.WriteLine("  • Рекордсмен по количеству титулов в Ла Лиге");
        }

        private void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"⚠ Ошибка: {ex.Message}");
            Console.ResetColor();
            Console.WriteLine("Используются локальные данные...\n");
        }

        private void DisplayExecutionTime(long milliseconds)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n⌛ Время выполнения: {milliseconds} мс");
            Console.ResetColor();
        }

        public void Dispose()
        {
            _requestService?.Dispose();
        }
    }
}
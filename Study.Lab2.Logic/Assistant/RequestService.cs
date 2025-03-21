﻿using Study.Lab2.Logic.Interfaces.Assistant;

namespace Study.Lab2.Logic.Assistant
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string FetchData(string url)
        {
            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            using (var stream = response.Content.ReadAsStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public async Task<string> FetchDataAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

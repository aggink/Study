using Study.Lab2.Logic.Interfaces.Assistant;

namespace Study.Lab2.Logic.Assistant
{
    public class RequestService : IRequestService
    {
        public string FetchData(string url)
        {
            using var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = httpClient.Send(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<string> FetchDataAsync(string url)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}

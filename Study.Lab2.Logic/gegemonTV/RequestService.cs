using Study.Lab2.Logic.Interfaces.gegemonTV;
using System.Text;

namespace Study.Lab2.Logic.gegemonTV
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
                throw new Exception($"[ERROR]: {response.StatusCode} - {response.ReasonPhrase}");
            }

            using (var stream = response.Content.ReadAsStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"[ERROR]: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    #region Utils
    public class JsonHelper
    {
        private const string INDENT_STRING = "\t";
        public static string FormatJson(string str)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }

    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
    #endregion
}

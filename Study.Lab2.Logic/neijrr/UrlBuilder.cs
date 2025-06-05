using System.Text;
using Study.Lab2.Logic.Interfaces.neijrr;

namespace Study.Lab2.Logic.neijrr
{
    public class UrlBuilder : IUrlBuilder
    {
        private string _protocol;
        private string _baseUrl;

        public string BaseUrl
        {
            get { return $"{_protocol}://{_baseUrl}/"; }
            set
            {
                value = value.TrimEnd('/');

                if (value.Contains("://"))
                {
                    var splitUrl = value.Split(
                        "://", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                    );

                    if (splitUrl.Length != 2)
                        throw new ArgumentException("Протокол указан больше одного раза", nameof(value));

                    _protocol = splitUrl[0];
                    _baseUrl = splitUrl[1];
                }
                else
                {
                    _protocol = null;
                    _baseUrl = value;
                }
            }
        }

        public UrlBuilder(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string Url(List<object> path = null, string protocol = null, Dictionary<object, object> parameters = null)
        {
            var sb = new StringBuilder();
            sb.Append(protocol ?? _protocol);
            sb.Append("://");
            sb.Append(_baseUrl);

            if (path is not null)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    sb.Append('/');
                    sb.Append(path[i]);
                }
            }

            if (parameters is not null)
            {
                sb.Append('?');
                for (int i = 0; i < parameters.Count; i++)
                {
                    sb.Append(parameters.ElementAt(i).Key);
                    sb.Append('=');
                    sb.Append(parameters.ElementAt(i).Value);

                    if (i < parameters.Count - 1)
                        sb.Append('&');
                }
            }
            else
                sb.Append('/');

            return sb.ToString();
        }
    }
}

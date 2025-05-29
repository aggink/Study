using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.Interfaces.SuperSalad007
{
    public interface IRequestService : IDisposable
    {
        /// <summary>
        /// Отправить запрос к сервису
        /// </summary>
        /// <param name="url">Веб-адрес</param>
        /// <returns>Ответ от сервиса</returns>
        string FetchData(string url);

        /// <summary>
        /// Отправить запрос к сервису
        /// </summary>
        /// <param name="url">Веб-адрес</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Ответ от сервиса</returns>
        Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
    }
}

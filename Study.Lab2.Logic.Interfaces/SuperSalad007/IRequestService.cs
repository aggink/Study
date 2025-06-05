using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.Interfaces.SuperSalad007;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// Send a request to the service
    /// </summary>
    /// <param name="url">Web-adress</param>
    /// <returns>Response from the service</returns>
    string FetchData(string url);

    /// <summary>
    /// Send a request to the service
    /// </summary>
    /// <param name="url">Web-adress</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Response from the service</returns>
    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}

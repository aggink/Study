using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.Interfaces.SuperSalad007
{
    public interface IRequestService : IDisposable
    {
        string FetchData(string url);

        Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
    }
}

using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.AsianComics;

namespace Study.Lab3.Logic.Interfaces.Services.AsianComics;

public interface IManhvaService
{
    /// <summary>
    /// Проверка модели манги на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="manhva">Манхва</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateManhvaValidateAndThrowAsync(
        DataContext dataContext,
        Manhva manhva,
        CancellationToken cancellationToken = default);
}

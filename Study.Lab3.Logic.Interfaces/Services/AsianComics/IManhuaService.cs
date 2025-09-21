using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.AsianComics;

namespace Study.Lab3.Logic.Interfaces.Services.AsianComics;

public interface IManhuaService
{
    /// <summary>
    /// Проверка модели манги на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="manhua">Маньхуа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateManhuaValidateAndThrowAsync(
        DataContext dataContext,
        Manhua manhua,
        CancellationToken cancellationToken = default);
}

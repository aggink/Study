using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Interfaces.Services.Shelter;

public interface ICatService
{
    /// <summary>
    /// Проверка модели кота на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="cat">Кот</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCatValidateAndThrowAsync(
        DataContext dataContext,
        Cat cat,
        CancellationToken cancellationToken = default);
}
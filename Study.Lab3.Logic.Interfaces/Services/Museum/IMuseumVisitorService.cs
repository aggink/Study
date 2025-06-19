using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;

namespace Study.Lab3.Logic.Interfaces.Services.Museum;

public interface IMuseumVisitorService
{
    /// <summary>
    /// Проверка модели посетителя на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="visitor">Посетитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateVisitorValidateAndThrowAsync(
        DataContext dataContext,
        MuseumVisitor visitor,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления посетителя
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="visitor">Посетитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MuseumVisitor visitor,
        CancellationToken cancellationToken = default);
}

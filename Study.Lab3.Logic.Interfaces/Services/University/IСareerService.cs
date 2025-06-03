using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface ICareerService
{
    /// <summary>
    /// Проверка модели карьеры на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="career">карьера</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCareerValidateAndThrowAsync(
        DataContext dataContext,
        Career career,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления показа профессии
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="career">каррьера</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Career career,
        CancellationToken cancellationToken = default);
}
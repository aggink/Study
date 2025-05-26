using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;
//Обработка преподавателя
public interface ITeacherService
{
    /// <summary>
    /// Проверка модели учителя на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacher">Учитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateTeacherValidateAndThrowAsync(
        DataContext dataContext,
        Teacher teacher,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления учителя
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacher">Учитель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Teacher teacher,
        CancellationToken cancellationToken = default);
}
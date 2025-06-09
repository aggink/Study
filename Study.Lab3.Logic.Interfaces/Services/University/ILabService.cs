using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface ILabService
{
    /// <summary>
    /// Проверка модели группы на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="lab">Группа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateLabValidateAndThrowAsync(
        DataContext dataContext,
        Labs lab,
        CancellationToken cancellationToken = default);
    Task CreateOrUpdateStudentLabValidateAndThrowAsync(
       DataContext dataContext,
       StudentLab studentlab,
       CancellationToken cancellationToken = default);

}

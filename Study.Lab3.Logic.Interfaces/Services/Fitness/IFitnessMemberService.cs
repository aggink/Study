using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Interfaces.Services.Fitness;

public interface IFitnessMemberService
{
    /// <summary>
    /// Проверка модели участника на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="member">Участник</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMemberValidateAndThrowAsync(
        DataContext dataContext,
        FitnessMember member,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления участника
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="member">Участник</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessMember member,
        CancellationToken cancellationToken = default);
}
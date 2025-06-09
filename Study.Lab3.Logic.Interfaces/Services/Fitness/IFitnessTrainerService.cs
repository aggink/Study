using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Interfaces.Services.Fitness;

public interface IFitnessTrainerService
{
    /// <summary>
    /// Проверка модели тренера на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="trainer">Тренер</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateTrainerValidateAndThrowAsync(
        DataContext dataContext,
        FitnessTrainer trainer,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления тренера
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="trainer">Тренер</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessTrainer trainer,
        CancellationToken cancellationToken = default);
}
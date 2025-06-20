using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Interfaces.Services.PetShop;

public interface IPetFoodService
{
    /// <summary>
    /// Проверка модели корма на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="petFood">Корм</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePetFoodValidateAndThrowAsync(
        DataContext dataContext,
        PetFood petFood,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления корма
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="petFood">Корм</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PetFood petFood,
        CancellationToken cancellationToken = default);
}

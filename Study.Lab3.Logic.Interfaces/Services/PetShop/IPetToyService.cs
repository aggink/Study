using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Interfaces.Services.PetShop;

public interface IPetToyService
{
    /// <summary>
    /// Проверка модели игрушки на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="petToy">Игрушка</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePetToyValidateAndThrowAsync(
        DataContext dataContext,
        PetToy petToy,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления игрушки
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="petToy">Игрушка</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PetToy petToy,
        CancellationToken cancellationToken = default);
}

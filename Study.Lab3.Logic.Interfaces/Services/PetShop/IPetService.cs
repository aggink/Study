using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Interfaces.Services.PetShop;

public interface IPetService
{
    /// <summary>
    /// Проверка модели животного на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="pet">Животное</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdatePetValidateAndThrowAsync(
        DataContext dataContext,
        Pet pet,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления животного
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="pet">Животное</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Pet pet,
        CancellationToken cancellationToken = default);
}
